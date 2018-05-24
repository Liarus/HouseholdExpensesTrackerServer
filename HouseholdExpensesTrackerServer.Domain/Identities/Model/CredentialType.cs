using HouseholdExpensesTrackerServer.Domain.Identities.Event;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class CredentialType : AggregateRoot<int>
    {
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public static CredentialType Create(Guid identity, string name, string code) 
            => new CredentialType(identity, name, code);

        public CredentialType Modify(string name, string code, int version)
        {
            this.Name = name;
            this.Code = code;
            this.Version = version;
            this.ApplyEvent(new CredentialTypeModifiedEvent(this.Identity, this.Id, code,
                name));
            return this;
        }

        public void Delete()
        {
            this.ApplyEvent(new CredentialTypeDeletedEvent(this.Identity, this.Id));
        }

        protected CredentialType(Guid identity, string name, string code)
        {
            this.Identity = identity;
            this.Name = name;
            this.Code = code;
            this.ApplyEvent(new CredentialTypeCreatedEvent(identity, code, name));
        }

        protected CredentialType()
        {

        }
    }
}
