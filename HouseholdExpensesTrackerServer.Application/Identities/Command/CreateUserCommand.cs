using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class CreateUserCommand : BaseCommand
    {
        public readonly string Name;

        public CreateUserCommand(string name)
        {
            this.Name = name;
        }
    }
}
