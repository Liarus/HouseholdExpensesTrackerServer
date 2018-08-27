using HouseholdExpensesTrackerServer.Application.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Identities.Command
{
    public class CreateRoleCommand : BaseCommand
    {
        public readonly string Name;

        public readonly string Code;

        public readonly ICollection<int> PermissionIds;

        public CreateRoleCommand(string name, string code, ICollection<int> permissionIds)
        {
            this.Name = name;
            this.Code = code;
            this.PermissionIds = permissionIds;
        }
    }
}
