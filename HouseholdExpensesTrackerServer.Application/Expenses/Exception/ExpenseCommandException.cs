using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Expenses.Exception
{
    public class ExpenseCommandException : System.Exception
    {
        public ExpenseCommandException(string message) : base(message)
        {

        }
    }
}
