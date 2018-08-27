using HouseholdExpensesTrackerServer.Domain.Definitions.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Credential : AuditableEntity<int>
    {
        public int UserId { get; protected set; }

        public int CredentialTypeId { get; protected set; }

        public string Identifier { get; protected set; }

        public string Secret { get; protected set; }

        public User User { get; protected set; }

        public static Credential Create(int credentialTypeId, string identifier, string secret)
            => new Credential(credentialTypeId, identifier, secret);

        protected Credential(int credentialTypeId, string identifier, string secret)
        {
            this.CredentialTypeId = credentialTypeId;
            this.Identifier = identifier;
            this.Secret = secret;
        }

        protected Credential()
        {

        }
    }
}
