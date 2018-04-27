using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    class UserModifiedEvent : BaseDomainEvent
    {
        public readonly int UserId;

        public readonly string Name;

        public UserModifiedEvent(Guid identity, int userId, string name)
            : base(identity)
        {
            this.UserId = userId;
            this.Name = name;
        }
    }
}
