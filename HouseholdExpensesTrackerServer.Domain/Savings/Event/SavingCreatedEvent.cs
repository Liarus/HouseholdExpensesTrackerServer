using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Event
{
    public class SavingCreatedEvent : BaseEvent
    {
        public readonly int HouseholdId;

        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Description;

        public readonly decimal Amount;

        public readonly DateTime Date;

        public SavingCreatedEvent(Guid identity, int householdId, int savingTypeId, string name, string description,
            decimal amount, DateTime date)
            :base(identity)
        {
            this.HouseholdId = householdId;
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
        }
    }
}
