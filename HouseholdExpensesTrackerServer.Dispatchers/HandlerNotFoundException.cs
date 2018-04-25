using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Dispatchers
{
    public class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(string eventName, string dispatcherName) : 
            base($"Hanlder for event: {eventName} in dispatcher {dispatcherName} has not been found")
        {

        }
    }
}
