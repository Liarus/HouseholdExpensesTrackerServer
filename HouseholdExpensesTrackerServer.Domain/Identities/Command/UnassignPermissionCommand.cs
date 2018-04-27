using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class UnassignPermissionCommand : ICommandHandler
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
