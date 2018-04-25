using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Role : AggregateRoot
    {
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;

        private readonly List<RolePermission> _rolePermissions;

        public static Role Create(Guid aggregateId, string name, string code) => new Role(aggregateId, name, code);

        public Role Modify(string name, string code)
        {
            this.Name = name;
            this.Code = code;
            return this;
        }

        protected Role(Guid aggregateId, string name, string code)
        {
            this.AggregateId = aggregateId;
            this.Name = name;
            this.Code = code;
            _rolePermissions = new List<RolePermission>();
        }

        protected Role()
        {

        }
    }
}
