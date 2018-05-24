using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class PermissionDeletedEvent : BaseEvent
    {
        public readonly int PermissionId;

        public PermissionDeletedEvent(Guid identity, int permissionId) : base(identity)
        {
            this.PermissionId = permissionId;
        }
    }
}
