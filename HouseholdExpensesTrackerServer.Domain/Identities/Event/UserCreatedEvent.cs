using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class UserCreatedEvent : BaseDomainEvent
    {
        public readonly string Name;

        public UserCreatedEvent(Guid identity, string name) : base(identity)
        {
            this.Name = name;
        }
    }
}
