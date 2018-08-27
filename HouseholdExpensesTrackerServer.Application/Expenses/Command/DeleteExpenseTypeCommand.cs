using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Expenses.Command
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
