using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class DeleteRoleCommand : BaseCommand
    {
        public readonly int RoleId;

        public DeleteRoleCommand(int roleId)
        {
            this.RoleId = roleId;
        }
    }
}
