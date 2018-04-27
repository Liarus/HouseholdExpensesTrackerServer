using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Command
{
    public class ModifyRoleCommand : ICommandHandler
    {
        public readonly int RoleId;

        public readonly string Name;

        public readonly string Code;

        public readonly string RowVersion;

        public ModifyRoleCommand(int roleId, string name, 
            string code, string rowVersion)
        {
            this.RoleId = roleId;
            this.Code = code;
            this.Name = name;
            this.RowVersion = rowVersion;
        }
    }
}
