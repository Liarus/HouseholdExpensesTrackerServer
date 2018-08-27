using HouseholdExpensesTrackerServer.Domain.Definitions.Object;
using HouseholdExpensesTrackerServer.Domain.Expenses.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Model
{
    public class ExpenseType: AggregateRoot<int>
    {
        public int UserId { get; protected set; }

        public string Name { get; protected set; }

        public string Symbol { get; protected set; }

        public static ExpenseType Create(Guid identity, int userId, string name, string symbol)
            => new ExpenseType(identity, userId, name, symbol);

        public ExpenseType Modify(string name, string symbol, int version)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Version = version;
            this.ApplyEvent(new ExpenseTypeModifiedEvent(this.Identity, this.Id, name, symbol));
            return this;
        }

        protected ExpenseType(Guid identity, int userId, string name, string symbol)
        {
            this.Identity = identity;
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
            this.ApplyEvent(new ExpenseTypeCreatedEvent(identity, userId, name, symbol));
        }

        protected ExpenseType()
        {

        }
    }
}
