using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
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
