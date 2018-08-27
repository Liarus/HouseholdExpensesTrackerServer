using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class AssignRoleCommand : BaseCommand
    {
        public readonly int UserId;

        public readonly int RoleId;

        public AssignRoleCommand(int userId, int roleId)
        {
            this.RoleId = roleId;
            this.UserId = userId;
        }
    }
}
