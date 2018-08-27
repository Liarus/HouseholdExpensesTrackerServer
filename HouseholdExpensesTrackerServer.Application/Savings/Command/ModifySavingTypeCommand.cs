using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Command
{
    public class ModifySavingTypeCommand : BaseCommand
    {
        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Symbol;

        public readonly int Version;

        public ModifySavingTypeCommand(int savingTypeId, string name, string symbol, int version)
        {
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Symbol = symbol;
            this.Version = version;
        }
    }
}
