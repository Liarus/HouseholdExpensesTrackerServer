using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class RoleDeletedEvent : BaseEvent
    {
        public readonly int RoleId;

        public RoleDeletedEvent(Guid identity, int roleId) : base(identity)
        {
            this.RoleId = roleId;
        }
    }
}
