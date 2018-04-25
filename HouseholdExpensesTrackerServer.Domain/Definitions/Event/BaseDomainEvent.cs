using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Event
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        public Guid AggregateId { get; set; }

        public int AggregateVersion { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}
