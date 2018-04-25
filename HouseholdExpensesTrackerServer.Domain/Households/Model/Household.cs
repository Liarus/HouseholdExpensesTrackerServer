using HouseholdExpensesTrackerServer.Domain.Expenses;
using HouseholdExpensesTrackerServer.Domain.Savings;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Households.Model
{
    public class Household : AggregateRoot<int>
    {
        public int UserId { get; protected set; }

        public string Name { get; protected set; }

        public string Symbol { get; protected set; }

        public string Description { get; protected set; }

        public virtual Address Address { get; protected set; }

        public static Household Create(Guid identity, int userId, string name, string symbol, string description,
            Address address) => new Household(identity, userId, name, symbol, description, address);

        public Household Modify(string name, string description, Address address)
        {
            this.Name = name;
            this.Description = description;
            this.Address = address;
            return this;
        }

        protected Household(Guid identity, int userId, string name, string symbol, string description, Address address)
        {
            this.Identity = identity;
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
            this.Description = description;
            this.Address = address;
        }

        protected Household()
        {

        }
    }
}
