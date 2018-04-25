using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Role : AggregateRoot<int>
    {
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;

        private readonly List<RolePermission> _rolePermissions;

        public static Role Create(Guid identity, string name, string code) => new Role(identity, name, code);

        public Role Modify(string name, string code)
        {
            this.Name = name;
            this.Code = code;
            return this;
        }

        protected Role(Guid identity, string name, string code)
        {
            this.Identity = identity;
            this.Name = name;
            this.Code = code;
            _rolePermissions = new List<RolePermission>();
        }

        protected Role()
        {

        }
    }
}
