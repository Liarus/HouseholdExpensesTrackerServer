using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Expenses.Exception
{
    public class ExpenseTypeCommandException : System.Exception
    {
        public ExpenseTypeCommandException(string message) : base(message)
        {

        }
    }
}
