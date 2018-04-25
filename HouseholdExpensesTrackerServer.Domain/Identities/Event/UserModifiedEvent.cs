using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    class UserModifiedEvent : BaseDomainEvent
    {
        public int UserId { get; private set; }

        public string OldName { get; private set; }

        public string NewName { get; private set; }

        public UserModifiedEvent(Guid identity, DateTimeOffset timeStamp, int userId, string oldName, string newName)
            : base(identity, timeStamp)
        {
            this.UserId = userId;
            this.OldName = oldName;
            this.NewName = newName;
        }
    }
}
