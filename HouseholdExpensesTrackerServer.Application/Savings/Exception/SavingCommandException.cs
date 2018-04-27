using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Exception
{
    public class SavingCommandException : System.Exception
    {
        public SavingCommandException(string message) : base(message)
        {

        }
    }
}
