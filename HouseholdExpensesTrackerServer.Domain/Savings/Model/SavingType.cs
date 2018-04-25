using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Model
{
    public class SavingType : AggregateRoot
    {
        public int UserId { get; protected set; }

        public string Name { get; protected set; }

        public string Symbol { get; protected set; }

        public static SavingType Create(int userId, string name, string symbol)
            => new SavingType(userId, name, symbol);

        public SavingType Modify(string name, string symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
            return this;
        }

        protected SavingType(int userId, string name, string symbol)
        {
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
        }

        protected SavingType()
        {

        }
    }
}
