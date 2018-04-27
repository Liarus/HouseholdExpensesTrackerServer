﻿using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class CreateRoleCommand : BaseCommand
    {
        public readonly string Name;

        public readonly string Code;

        public CreateRoleCommand(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }
    }
}
