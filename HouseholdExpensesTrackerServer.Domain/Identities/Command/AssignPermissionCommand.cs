using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class AssignPermissionCommand : BaseCommand
    {
        public readonly int PermissionId;

        public readonly int RoleId;

        public AssignPermissionCommand(int permissionId, int roleId)
        {
            this.RoleId = roleId;
            this.PermissionId = permissionId;
        }
    }
}
