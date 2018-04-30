using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class UnassignRoleCommand : BaseCommand
    {
        public readonly int UserId;

        public readonly int RoleId;

        public UnassignRoleCommand(int userId, int roleId)
        {
            this.RoleId = roleId;
            this.UserId = userId;
        }
    }
}
