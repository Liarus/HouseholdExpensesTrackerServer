using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class CredentialAddedEvent : BaseDomainEvent
    {
        public readonly int UserId;

        public readonly int CredentialTypeId;

        public readonly string Identifier;

        public CredentialAddedEvent(Guid identity, int userId, int credentialTypeId, string identifier)
            : base(identity)
        {
            this.UserId = userId;
            this.CredentialTypeId = credentialTypeId;
            this.Identifier = identifier;
        }
    }
}
