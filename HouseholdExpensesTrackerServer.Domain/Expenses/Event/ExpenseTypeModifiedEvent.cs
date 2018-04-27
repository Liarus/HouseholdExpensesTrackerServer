using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Event
{
    public class ExpenseTypeModifiedEvent : BaseDomainEvent
    {
        public readonly int ExpenseTypeId;

        public readonly string Name;

        public readonly string Symbol;

        public ExpenseTypeModifiedEvent(Guid identity, int expenseTypeId, string name, string symbol)
            :base(identity)
        {
            this.ExpenseTypeId = expenseTypeId;
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}
