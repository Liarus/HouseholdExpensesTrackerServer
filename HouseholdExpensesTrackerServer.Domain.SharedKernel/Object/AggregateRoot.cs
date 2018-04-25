using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public abstract class AggregateRoot<TIdentity> : AuditableEntity<TIdentity>, IAggregateRoot
    {
        public Guid Identity { get; protected set; }

        public IReadOnlyCollection<IDomainEvent> Events => _events;

        protected readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public void ClearEvents() => _events.Clear();

        public IDomainEvent[] FlushUncommitedEvents()
        {
            var events = _events.ToArray();
            _events.Clear();
            return events;
        }

        protected void ApplyEvent(IDomainEvent @event) => _events.Add(@event);
    }
}
