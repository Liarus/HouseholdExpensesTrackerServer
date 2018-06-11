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

        public readonly ICollection<int> PermissionIds;

        public readonly int Version;

        public ModifyRoleCommand(int roleId, string name, 
            string code, ICollection<int> permissionIds, int version)
        {
            this.RoleId = roleId;
            this.Code = code;
            this.Name = name;
            this.PermissionIds = permissionIds;
            this.Version = version;
        }
    }
}
