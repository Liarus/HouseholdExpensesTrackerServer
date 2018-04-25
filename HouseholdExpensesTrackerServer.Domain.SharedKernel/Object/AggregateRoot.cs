using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public class AggregateRoot : AuditableEntity, IAggregateRoot
    {
        public Guid AggregateId { get; protected set; }

        public int Version { get; protected set; }

        public IReadOnlyCollection<IDomainEvent> Events => _events;

        protected readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public void ClearEvents() => _events.Clear();

        public void LoadFromHistory(IEnumerable<IDomainEvent> history)
        {
            foreach (var e in history)
            {
                if (e.AggregateVersion != Version + 1)
                {
                    throw new DomainEventOutOfOrderException(e.AggregateId, this.GetType().Name);
                }
                ApplyEvent(e);
                AggregateId =  e.AggregateId;
                Version++;
            }
        }

        public IDomainEvent[] FlushUncommitedEvents()
        {
            var events = _events.ToArray();
            var i = 0;
            foreach (var @event in events)
            {
                    if (@event.AggregateId == Guid.Empty && AggregateId == Guid.Empty)
                    {
                        throw new AggregateOrEventMissingIdException(this.GetType().Name, @event.GetType().Name);
                    }
                    if (@event.AggregateId == Guid.Empty)
                    {
                        @event.AggregateId = AggregateId;
                    }
                    i++;
                    @event.AggregateVersion = Version + i;
                    @event.TimeStamp = DateTimeOffset.UtcNow;
            }
            Version = Version + events.Length;
            _events.Clear();
            return events;
        }

        protected void ApplyEvent(IDomainEvent @event) => _events.Add(@event);
    }
}
