using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Households.Event
{
    public class HouseholdCreatedEvent : BaseEvent
    {
        public readonly int UserId;

        public readonly string Name;

        public readonly string Symbol;

        public readonly string Description;

        public readonly string Street;

        public readonly string City;

        public readonly string Country;

        public readonly string ZipCode;

        public HouseholdCreatedEvent(Guid identity, int userId, string name, string symbol, 
            string description, string street, string city, string country, string zipcode)
            :base(identity)
        {
            this.UserId = userId;
            this.Name = name;
            this.Symbol = symbol;
            this.Description = description;
            this.Street = street;
            this.City = city;
            this.Country = country;
            this.ZipCode = zipcode;
        }
    }
}
