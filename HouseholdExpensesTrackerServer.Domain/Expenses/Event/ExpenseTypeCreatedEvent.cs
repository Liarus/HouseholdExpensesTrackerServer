﻿using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Event
{
    public class ExpenseTypeCreatedEvent : BaseDomainEvent
    {
        public readonly int UserId;

        public readonly string Name;

        public readonly string Symbol;

        public ExpenseTypeCreatedEvent(Guid identity, int userId, string name, string symbol)
            :base(identity)
        {
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
