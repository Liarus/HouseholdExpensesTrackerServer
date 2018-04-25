using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository
{
    public class AggregateDescriptor
    {
       public AggregateRoot Aggregate { get; protected set; }

       public int Version { get; protected set; }

        public AggregateDescriptor(AggregateRoot aggregate, int version)
        {
            this.Aggregate = aggregate;
            this.Version = version;
        }
    }
}
