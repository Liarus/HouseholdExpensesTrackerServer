using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception
{
    public class AggregateOrEventMissingIdException : System.Exception
    {
        public AggregateOrEventMissingIdException(string aggregateName, string eventName) :
            base($"An event of name {eventName} was tried to save from {aggregateName} but no id where set on either")
        {

        }
    }
}
