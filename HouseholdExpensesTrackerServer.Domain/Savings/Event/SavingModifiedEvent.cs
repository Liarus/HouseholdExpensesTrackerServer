using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Event
{
    public class SavingModifiedEvent : BaseEvent
    {
        public readonly int SavingId;

        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Description;

        public readonly decimal Amount;

        public readonly DateTime Date;

        public SavingModifiedEvent(Guid identity, int savingId, int savingTypeId, string name, string description,
            decimal amount, DateTime date)
            :base(identity)
        {
            this.SavingId = savingId;
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.Date = date;
        }
    }
}
