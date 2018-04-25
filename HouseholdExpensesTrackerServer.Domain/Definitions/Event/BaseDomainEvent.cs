using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Event
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        public DateTimeOffset TimeStamp { get; set; }
    }
}
