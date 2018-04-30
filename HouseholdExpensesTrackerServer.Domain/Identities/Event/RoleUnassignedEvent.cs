using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class RoleUnassignedEvent : BaseEvent
    {
        public readonly int RoleId;

        public readonly int UserId;

        public RoleUnassignedEvent(Guid identity, int roleId, int userId)
            :base(identity)
        {
            this.RoleId = roleId;
            this.UserId = userId;
        }
    }
}
