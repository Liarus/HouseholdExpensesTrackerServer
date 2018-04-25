using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Event
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        protected BaseDomainEvent(Guid identity, DateTimeOffset timeStamp)
        {
            this.Identity = identity;
            this.TimeStamp = timeStamp;
        }

        public Guid Identity { get; private set; }

        public DateTimeOffset TimeStamp { get; private set; }
    }
}
