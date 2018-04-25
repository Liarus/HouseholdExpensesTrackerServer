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

        public static CredentialType Create(string name, string code) 
            => new CredentialType(name, code);

        protected CredentialType(string name, string code)
        {
            this.Name = name;
            this.Code = code;
        }

        protected CredentialType()
        {

        }
    }
}
