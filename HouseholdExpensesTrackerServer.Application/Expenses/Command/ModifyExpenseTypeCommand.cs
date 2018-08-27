using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Expenses.Command
{
    public class ModifyExpenseTypeCommand : BaseCommand
    {
        public readonly int ExpenseTypeId;

        public readonly string Name;

        public readonly string Symbol;

        public readonly int Version;

        public ModifyExpenseTypeCommand(int expenseTypeId, string name, string symbol, int version)
        {
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Symbol = symbol;
            this.Version = version;
        }
    }
}
