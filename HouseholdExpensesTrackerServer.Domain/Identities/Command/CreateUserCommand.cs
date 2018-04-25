using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class CreateUserCommand : BaseCommand
    {
        public readonly string Name;

        public CreateUserCommand(Guid aggregateId, string name)
        {
            this.Name = name;
        }
    }
}
