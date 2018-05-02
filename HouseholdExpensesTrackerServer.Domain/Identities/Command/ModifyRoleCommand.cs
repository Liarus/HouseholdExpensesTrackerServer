using HouseholdExpensesTrackerServer.Domain.Definitions.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyRoleCommand : BaseCommand
    {
        public readonly int RoleId;

        public readonly string Name;

        public readonly string Code;

        public readonly int Version;

        public ModifyRoleCommand(int roleId, string name, 
            string code, int version)
        {
            this.RoleId = roleId;
            this.Code = code;
            this.Name = name;
            this.Version = version;
        }
    }
}
