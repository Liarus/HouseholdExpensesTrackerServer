using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
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

        public static ExpenseType Create(int userId, string name, string symbol) 
            => new ExpenseType(userId, name, symbol);

        public ExpenseType Modify(string name, string symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
            return this;
        }

        protected ExpenseType(int userId, string name, string symbol)
        {
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
        }

        protected ExpenseType()
        {

        }
    }
}
