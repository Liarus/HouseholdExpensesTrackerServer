using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HouseholdExpensesTrackerServer.Domain.Identities.Event;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class User : AggregateRoot<int>
    {
        public string Name { get; protected set; }

        public IReadOnlyCollection<Credential> Credentials => _credentials;

        public IReadOnlyCollection<UserRole> UserRoles => _userRoles;

        private readonly List<Credential> _credentials;

        private readonly List<UserRole> _userRoles;

        public static User Create(Guid identity, string name) => new User(identity, name);

        public User Modify(string name, string rowVersion)
        {
            this.ApplyEvent(new UserModifiedEvent(this.Identity, DateTime.Now, this.Id, this.Name, name));
            this.Name = name;
            this.RowVersion = Convert.FromBase64String(rowVersion);
            return this;
        }

        public void AddCredential(Credential credential)
        {
            _credentials.Add(credential);
            this.ApplyEvent(new CredentialAddedEvent(this.Identity, DateTime.Now, 
                this.Id, credential.CredentialTypeId, credential.Identifier));
        }

        protected User(Guid identity, string name)
        {
            this.Identity = identity;
            this.Name = name;
            _credentials = new List<Credential>();
            _userRoles = new List<UserRole>();
            this.ApplyEvent(new UserCreatedEvent(this.Identity, DateTime.Now, name));
        }

        protected User()
        {
            _credentials = new List<Credential>();
            _userRoles = new List<UserRole>();
        }
    }
}
