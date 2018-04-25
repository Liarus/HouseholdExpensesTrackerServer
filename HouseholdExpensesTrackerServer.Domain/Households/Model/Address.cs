using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Households.Model
{
    public class Address : ValueObject
    {
        public string Street { get; protected set; }

        public string City { get; protected set; }

        public string Country { get; protected set; }

        public string ZipCode { get; protected set; }

        public static Address Create(string country, string zipCode, string city, string street)
            => new Address(country, zipCode, city, street);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }

        protected Address(string country, string zipCode, string city, string street)
        {
            this.Country = country;
            this.ZipCode = zipCode;
            this.City = city;
            this.Street = street;
        }
        protected Address()
        {

        }
    }
}
