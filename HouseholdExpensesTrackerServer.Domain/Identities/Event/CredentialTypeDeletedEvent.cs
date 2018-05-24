using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class CredentialTypeDeletedEvent : BaseEvent
    {
        public readonly int CredentialTypeId;

        public CredentialTypeDeletedEvent(Guid identity, int credentialTypeId) : base(identity)
        {
            this.CredentialTypeId = credentialTypeId;
        }
    }
}
