using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class CreateCredentialTypeCommand : BaseCommand
    {
        public readonly string Name;

        public readonly string Code;

        public CreateCredentialTypeCommand(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }
    }
}
