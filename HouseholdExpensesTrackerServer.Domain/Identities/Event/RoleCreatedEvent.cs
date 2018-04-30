using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class RoleCreatedEvent : BaseEvent
    {
        public readonly string Code;

        public readonly string Name;

        public RoleCreatedEvent(Guid identity, string code, string name) : base(identity)
        {
            this.Code = code;
            this.Name = name;
        }
    }
}
