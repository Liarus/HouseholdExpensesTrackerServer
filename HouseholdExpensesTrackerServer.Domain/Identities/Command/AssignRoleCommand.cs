using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class AssignRoleCommand : ICommandHandler
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
