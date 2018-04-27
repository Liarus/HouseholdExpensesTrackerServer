using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyPermissionCommand : ICommandHandler
    {
        public readonly int PermissionId;

        public readonly string Name;

        public readonly string Code;

        public readonly string RowVersion;

        public ModifyPermissionCommand(int permissionId, string name, 
            string code, string rowVersion)
        {
            this.PermissionId = permissionId;
            this.Code = code;
            this.Name = name;
            this.RowVersion = rowVersion;
        }
    }
}
