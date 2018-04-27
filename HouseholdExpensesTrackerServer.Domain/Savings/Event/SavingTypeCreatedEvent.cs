using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Event
{
    public class SavingTypeCreatedEvent : BaseDomainEvent
    {
        public readonly int UserId;

        public readonly string Name;

        public readonly string Symbol;

        public SavingTypeCreatedEvent(Guid identity, int userId, string name, string symbol)
            :base(identity)
        {
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
