using HouseholdExpensesTrackerServer.Common.Event;
using HouseholdExpensesTrackerServer.Common.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Object
{
    public abstract class AggregateRoot<TIdentity> : AuditableEntity<TIdentity>, IAggregateRoot
    {
        public Guid Identity { get; protected set; }

        public IReadOnlyCollection<IEvent> Events => _events;

        protected readonly List<IEvent> _events = new List<IEvent>();

        public void ClearEvents() => _events.Clear();

        public IEvent[] FlushUncommitedEvents()
        {
            var events = _events.ToArray();
            _events.Clear();
            return events;
        }

        protected void ApplyEvent(IEvent @event) => _events.Add(@event);
    }
}
