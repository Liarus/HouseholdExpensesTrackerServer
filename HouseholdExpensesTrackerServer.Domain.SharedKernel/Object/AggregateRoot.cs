using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public class AggregateRoot<TIdentifier> : AuditableEntity<TIdentifier>, IAggregateRoot
    {
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
                    throw new DomainEventOutOfOrderException(e.AggregateId, nameof(AggregateRoot<TIdentifier>));
                }
                ApplyEvent(e);
                Id =  TConverter.ChangeType<TIdentifier>(e.AggregateId.Id);
                Version++;
            }
        }

        protected void ApplyEvent(IDomainEvent @event) => _events.Add(@event);
    }
}
