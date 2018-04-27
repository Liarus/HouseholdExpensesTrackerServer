using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Command
{
    public class ModifySavingTypeCommand : BaseCommand
    {
        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Symbol;

        public readonly string RowVersion;

        public ModifySavingTypeCommand(int savingTypeId, string name, string symbol, string rowVersion)
        {
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Symbol = symbol;
            this.RowVersion = rowVersion;
        }
    }
}
