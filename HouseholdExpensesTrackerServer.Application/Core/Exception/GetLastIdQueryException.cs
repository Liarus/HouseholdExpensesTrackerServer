using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Core.Exception
{
    public class GetLastIdQueryException : System.Exception
    {
        public GetLastIdQueryException(string message) : base(message)
        {

        }
    }
}
