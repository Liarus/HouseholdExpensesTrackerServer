using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyUserCommand : ICommandHandler
    {
        public readonly int UserId;

        public readonly string Name;

        public readonly string RowVersion;

        public ModifyUserCommand(int userId, string name, string rowVersion)
        {
            this.UserId = userId;
            this.Name = name;
            this.RowVersion = rowVersion;
        }
    }
}
