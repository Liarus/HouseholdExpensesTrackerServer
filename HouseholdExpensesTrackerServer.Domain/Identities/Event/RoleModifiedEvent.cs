using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class RoleModifiedEvent : BaseEvent
    {
        public readonly int RoleId;

        public readonly string Code;

        public readonly string Name;

        public RoleModifiedEvent(Guid identity, int roleId, 
            string code, string name) : base(identity)
        {
            this.RoleId = roleId;
            this.Code = code;
            this.Name = name;
        }
    }
}
