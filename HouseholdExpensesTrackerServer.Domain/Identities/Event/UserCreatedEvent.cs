using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class UserCreatedEvent : BaseDomainEvent
    {
        private readonly string name;

        public UserCreatedEvent(string name)
        {
            this.name = name;
        }
    }
}
