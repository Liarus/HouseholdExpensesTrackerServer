using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Command
{
    public class ModifyExpenseTypeCommand : BaseCommand
    {
        public readonly int ExpenseTypeId;

        public readonly string Name;

        public readonly string Symbol;

        public readonly string RowVersion;

        public ModifyExpenseTypeCommand(int expenseTypeId, string name, string symbol, string rowVersion)
        {
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Symbol = symbol;
            this.RowVersion = rowVersion;
        }
    }
}
