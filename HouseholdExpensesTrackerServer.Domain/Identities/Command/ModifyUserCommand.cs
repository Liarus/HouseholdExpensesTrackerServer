using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyUserCommand : ICommand
    {
        public int UserId { get; private set; }

        public string Name { get; private set; }

        public string RowVersion { get; private set; }

        public ModifyUserCommand(int userId, string name, string rowVersion)
        {
            this.UserId = userId;
            this.Name = name;
            this.RowVersion = rowVersion;
        }
    }
}
