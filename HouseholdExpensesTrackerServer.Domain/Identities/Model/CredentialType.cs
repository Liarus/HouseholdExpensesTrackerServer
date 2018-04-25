using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class CredentialType : AggregateRoot
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public static CredentialType Create(Guid aggregateId, string name, string code) 
            => new CredentialType(aggregateId, name, code);

        protected CredentialType(Guid aggregateId, string name, string code)
        {
            this.AggregateId = aggregateId;
            this.Name = name;
            this.Code = code;
        }

        protected CredentialType()
        {

        }
    }
}
