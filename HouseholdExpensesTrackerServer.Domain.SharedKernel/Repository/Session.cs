using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository
{
    public class Session : ISession
    {
        private readonly Dictionary<Guid, AggregateDescriptor> _trackedAggregates;

        private readonly IDomainEventDispatcher _eventDispatcher;

        private readonly IDomainEventStore _eventStore;

        public Session(IDomainEventDispatcher eventDispatcher, IDomainEventStore eventStore)
        {
            _eventDispatcher = eventDispatcher;
            _eventStore = eventStore;
            _trackedAggregates = new Dictionary<Guid, AggregateDescriptor>();
        }

        public Task Add<T>(T aggregate, 
            CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            var id = string.Format($"Name:{aggregate.GetType().Name}_Id:{aggregate.Id.ToString()}");

            if (!IsTracked(aggregate.AggregateId))
            {
                _trackedAggregates.Add(aggregate.AggregateId, 
                    new AggregateDescriptor(aggregate, aggregate.Version));
            }
            else if (_trackedAggregates[aggregate.AggregateId].Aggregate != aggregate)
            {
                throw new SessionConcurrencyException(aggregate.AggregateId);
            }
            return Task.FromResult(0);
        }

        public async Task Commit(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(_trackedAggregates.Values.Select(x => this.Save(x.Aggregate, x.Version, cancellationToken)));
            _trackedAggregates.Clear();
        }

        public async Task<T> Get<T>(Guid id, int? expectedVersion = null, 
            CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            if (IsTracked(id))
            {
                var trackedAggregate = (T)_trackedAggregates[id].Aggregate;
                if (expectedVersion != null && trackedAggregate.Version != expectedVersion)
                {
                    throw new SessionConcurrencyException(id);
                }
                return trackedAggregate;
            }

            var aggregate = await this.LoadAggregate<T>(id, cancellationToken);
            if (expectedVersion != null && aggregate.Version != expectedVersion)
            {
                throw new SessionConcurrencyException(id);
            }
            await Add(aggregate, cancellationToken);

            return aggregate;
        }

        protected bool IsTracked(Guid id)
        {
            return _trackedAggregates.ContainsKey(id);
        }

        protected async Task<T> LoadAggregate<T>(Guid id, 
            CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            var events = await _eventStore.Get(id, -1, cancellationToken);
            if (!events.Any())
            {
                throw new AggregateNotFoundException(id);
            }

            //var aggregate = AggregateFactory.CreateAggregate<T>();
            //aggregate.LoadFromHistory(events);
            //return aggregate;
            return null;
        }

        protected async Task Save<T>(T aggregate, int? expectedVersion = null, 
            CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            if (expectedVersion != null && (await _eventStore.Get(aggregate.AggregateId, 
                expectedVersion.Value, cancellationToken)).Any())
            {
                throw new SessionConcurrencyException(aggregate.AggregateId);
            }

            var changes = aggregate.FlushUncommitedEvents();
            await _eventStore.Save(changes, cancellationToken);

            if (_eventDispatcher != null)
            {
                foreach (var @event in changes)
                {
                    await _eventDispatcher.Publish(@event, cancellationToken);
                }
            }
        }
    }
}
