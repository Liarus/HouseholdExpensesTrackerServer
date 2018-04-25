using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class UserCreatedEvent : BaseDomainEvent
    {
        public string Name { get; private set; }

        public UserCreatedEvent(Guid identity, DateTimeOffset timeStamp, string name) : base(identity, timeStamp)
        {
            this.Name = name;
        }
    }
}
