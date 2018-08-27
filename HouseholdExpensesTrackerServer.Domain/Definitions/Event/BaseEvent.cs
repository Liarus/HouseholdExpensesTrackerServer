using HouseholdExpensesTrackerServer.Common.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Definitions.Event
{
    public abstract class BaseEvent : IEvent
    {
        protected BaseEvent(Guid identity)
        {
            this.Identity = identity;
            this.TimeStamp = DateTime.Now;
        }

        public readonly Guid Identity;

        public readonly DateTimeOffset TimeStamp;
    }
}
