using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class DeletePermissionCommand : BaseCommand
    {
        public readonly int PermissionId;

        public DeletePermissionCommand(int permissionId)
        {
            this.PermissionId = permissionId;
        }
    }
}
