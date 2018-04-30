using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class UnassignPermissionCommand : BaseCommand
    {
        public readonly int PermissionId;

        public readonly int RoleId;

        public UnassignPermissionCommand(int permissionId, int roleId)
        {
            this.RoleId = roleId;
            this.PermissionId = permissionId;
        }
    }
}
