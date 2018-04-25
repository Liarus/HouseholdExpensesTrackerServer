using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class CredentialAddedEvent : BaseDomainEvent
    {
        public int UserId { get; private set; }

        public int CredentialTypeId { get; private set; }
        
        public string Identifier { get; private set; }

        public CredentialAddedEvent(Guid identity, DateTimeOffset timeStamp, int userId, int credentialTypeId, string identifier)
            : base(identity, timeStamp)
        {
            this.UserId = userId;
            this.CredentialTypeId = credentialTypeId;
            this.Identifier = identifier;
        }
    }
}
