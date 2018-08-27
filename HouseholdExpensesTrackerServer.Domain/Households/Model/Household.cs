using HouseholdExpensesTrackerServer.Domain.Definitions.Object;
using HouseholdExpensesTrackerServer.Domain.Expenses;
using HouseholdExpensesTrackerServer.Domain.Households.Event;
using HouseholdExpensesTrackerServer.Domain.Savings;
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

        public Household Modify(string name, string symbol, string description, Address address, 
            int version)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Description = description;
            //this.Address = address;
            //EF core bug
            this.Address.UpdateFrom(address);
            this.Version = version;
            this.ApplyEvent(new HouseholdModifiedEvent(this.Identity, this.Id, name, symbol, description,  
                address.Street, address.City, address.Country, address.ZipCode));
            return this;
        }

        public void Delete()
        {
            this.ApplyEvent(new HouseholdDeletedEvent(this.Identity, this.Id));
        }

        protected Household(Guid identity, int userId, string name, string symbol, string description,
            Address address)
        {
            this.Identity = identity;
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
            this.Description = description;
            this.Address = address;
            this.ApplyEvent(new HouseholdCreatedEvent(identity, userId, name, symbol, description,
                address.Street, address.City, address.Country, address.ZipCode));
        }

        protected Household()
        {

        }
    }
}
