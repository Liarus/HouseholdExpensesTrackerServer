using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class CredentialTypeCreatedEvent : BaseDomainEvent
    {
        public readonly string Code;

        public readonly string Name;

        public CredentialTypeCreatedEvent(Guid identity, string code, string name) : base(identity)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
