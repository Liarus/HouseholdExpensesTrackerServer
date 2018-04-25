using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Exception
{
    public class DomainEventOutOfOrderException : System.Exception
    {
        public DomainEventOutOfOrderException(IIdValue aggregateId, string aggregateName) :
            base($"Domain event for aggregate {aggregateName} with id {aggregateId} is out of order")
        {

        }
    }
}
