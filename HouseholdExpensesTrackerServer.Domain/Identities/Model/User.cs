using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HouseholdExpensesTrackerServer.Domain.Identities.Event;
using HouseholdExpensesTrackerServer.Domain.Identities.Exception;

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

        public User Modify(string name, int version)
        {
            this.Name = name;
            this.Version = version;
            this.ApplyEvent(new UserModifiedEvent(this.Identity, this.Id, name));
            return this;
        }

        public void AddCredential(Credential credential)
        {
            _credentials.Add(credential);
            this.ApplyEvent(new CredentialAddedEvent(this.Identity, 
                this.Id, credential.CredentialTypeId, credential.Identifier));
        }

        public void AssignRole(int roleId)
        {
            var role = _userRoles.SingleOrDefault(e => e.RoleId == roleId);
            if (role != null)
            {
                throw new UserDomainException($"Role {roleId} is already assigned to user {this.Id}");

            }
            _userRoles.Add(new UserRole { RoleId = roleId });
            this.ApplyEvent(new RoleAssignedEvent(this.Identity, roleId, this.Id));
        }

        public void UnassignRole(int roleId)
        {
            var role = _userRoles.SingleOrDefault(e => e.RoleId == roleId && e.UserId == this.Id);
            if (role == null)
            {
                throw new UserDomainException($"Role {roleId} is not assigned to user {this.Id}");
            }
            _userRoles.Remove(role);
            this.ApplyEvent(new RoleUnassignedEvent(this.Identity, roleId, this.Id));
        }

        protected User(Guid identity, string name)
        {
            this.Identity = identity;
            this.Name = name;
            _credentials = new List<Credential>();
            _userRoles = new List<UserRole>();
            this.ApplyEvent(new UserCreatedEvent(this.Identity, name));
        }

        protected User()
        {
            _credentials = new List<Credential>();
            _userRoles = new List<UserRole>();
        }
    }
}
