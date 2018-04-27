using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Households.Exception
{
    public class HouseholdCommandException : System.Exception
    {
        public HouseholdCommandException(string message) : base(message)
        {

        }
    }
}
