using HouseholdExpensesTrackerServer.Domain.Expenses;
using HouseholdExpensesTrackerServer.Domain.Households;
using HouseholdExpensesTrackerServer.Domain.Savings;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class User : AggregateRoot
    {
        public string Name { get; protected set; }

        public IReadOnlyCollection<Credential> Credentials => _credentials;

        public IReadOnlyCollection<UserRole> UserRoles => _userRoles;

        private readonly List<Credential> _credentials;

        private readonly List<UserRole> _userRoles;

        public static User Create(Guid aggregateId, string name) => new User(aggregateId, name);

        public void AddCredential(Credential credential)
        {
            _credentials.Add(credential);
        }

        protected User(Guid aggregateId, string name)
        {
            this.AggregateId = aggregateId;
            this.Name = name;
            _credentials = new List<Credential>();
            _userRoles = new List<UserRole>();
        }

        protected User()
        {
            _credentials = new List<Credential>();
            _userRoles = new List<UserRole>();
        }
    }
}
