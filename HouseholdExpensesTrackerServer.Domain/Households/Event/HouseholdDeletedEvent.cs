using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Households.Event
{
    public class HouseholdDeletedEvent : BaseEvent
    {
        public readonly int HouseholdId;

        public HouseholdDeletedEvent(Guid identity, int householdId) : base(identity)
        {
            this.HouseholdId = householdId;
        }
    }
}
