using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception
{
    public class SessionConcurrencyException : System.Exception
    {
        public SessionConcurrencyException(Guid aggregateId) : 
            base($"A different version than expected was found in aggregate {aggregateId}")
        {

        }
    }
}
