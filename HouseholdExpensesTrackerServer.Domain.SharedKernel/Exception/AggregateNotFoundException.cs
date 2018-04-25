using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception
{
    public class AggregateNotFoundException : System.Exception
    {
        public AggregateNotFoundException(Guid aggregeteId) :
            base($"Domain event for aggregate {aggregeteId}")
        {
        }
    }
}
