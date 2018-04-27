using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class PermissionAssignedEvent : BaseDomainEvent
    {
        public readonly int RoleId;

        public readonly int PermissionId;

        public PermissionAssignedEvent(Guid identity, int roleId, int permissionId)
            :base(identity)
        {
            this.RoleId = roleId;
            this.PermissionId = permissionId;
        }
    }
}
