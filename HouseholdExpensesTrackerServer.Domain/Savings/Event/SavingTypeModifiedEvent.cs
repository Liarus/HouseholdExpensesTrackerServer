using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Event
{
    public class SavingTypeModifiedEvent : BaseDomainEvent
    {
        public readonly int SavingTypeId;

        public readonly string Name;

        public readonly string Symbol;

        public SavingTypeModifiedEvent(Guid identity, int savingTypeId, string name, string symbol)
            :base(identity)
        {
            this.SavingTypeId = savingTypeId;
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
