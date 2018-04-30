using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class CredentialTypeModifiedEvent : BaseEvent
    {
        public readonly int CredentialTypeId;

        public readonly string Code;

        public readonly string Name;

        public CredentialTypeModifiedEvent(Guid identity, int credentialTypeId, 
            string code, string name) : base(identity)
        {
            this.CredentialTypeId = credentialTypeId;
            this.Code = code;
            this.Name = name;
        }
    }
}
