using HouseholdExpensesTrackerServer.Domain.Definitions.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Event
{
    public class PermissionModifiedEvent : BaseEvent
    {
        public readonly int PermissionId;

        public readonly string Code;

        public readonly string Name;

        public PermissionModifiedEvent(Guid identity, int permissionId, 
            string code, string name) : base(identity)
        {
            this.PermissionId = permissionId;
            this.Code = code;
            this.Name = name;
        }
    }
}
