using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class CredentialType : AggregateRoot<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public static CredentialType Create(Guid identity, string name, string code) 
            => new CredentialType(identity, name, code);

        protected CredentialType(Guid identity, string name, string code)
        {
            this.Identity = identity;
            this.Name = name;
            this.Code = code;
        }

        protected CredentialType()
        {

        }
    }
}
