using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class ModifyPermissionCommand : BaseCommand
    {
        public readonly int PermissionId;

        public readonly string Name;

        public readonly string Code;

        public readonly int Version;

        public ModifyPermissionCommand(int permissionId, string name,
            string code, int version)
        {
            this.PermissionId = permissionId;
            this.Code = code;
            this.Name = name;
            this.Version = version;
        }
    }
}
