using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Event
{
    public abstract class BaseDomainEvent : IDomainEvent
    {
        protected BaseDomainEvent(Guid identity)
        {
            this.Identity = identity;
            this.TimeStamp = DateTime.Now;
        }

        public readonly Guid Identity;

        public readonly DateTimeOffset TimeStamp;
    }
}
