using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Command
{
    public class DeleteExpenseTypeCommand : BaseCommand
    {
        public readonly int ExpenseTypeId;

        public DeleteExpenseTypeCommand(int expenseTypeId)
        {
            this.ExpenseTypeId = expenseTypeId;
        }
    }
}
