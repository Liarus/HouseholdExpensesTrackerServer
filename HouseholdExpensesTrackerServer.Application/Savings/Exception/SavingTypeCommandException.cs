using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Exception
{
    public class SavingTypeCommandException : System.Exception
    {
        public SavingTypeCommandException(string message) : base(message)
        {

        }
    }
}
