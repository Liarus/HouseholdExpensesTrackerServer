using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HouseholdExpensesTrackerServer.Domain.Identities.Event;
using HouseholdExpensesTrackerServer.Domain.Identities.Exception;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Role : AggregateRoot<int>
    {
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;

        private readonly List<RolePermission> _rolePermissions;

        public static Role Create(Guid identity, string name, string code) 
            => new Role(identity, name, code);

        public Role Modify(string name, string code, int version)
        {
            this.Name = name;
            this.Code = code;
            this.Version = version;
            this.ApplyEvent(new RoleModifiedEvent(this.Identity,
                this.Id, code, name));
            return this;
        }

        public void AssignPermission(int permissionId)
        {
            var role = _rolePermissions.SingleOrDefault(e => e.PermissionId == permissionId);
            if (role != null)
            {
                throw new RoleDomainException($"Permission {permissionId} is already assigned to role {this.Id}");
            }
            _rolePermissions.Add(new RolePermission() { PermissionId = permissionId });
            this.ApplyEvent(new PermissionAssignedEvent(this.Identity, this.Id, permissionId));
        }

        public void UnassignPermission(int permissionId)
        {
            var permission = _rolePermissions.SingleOrDefault(e => e.PermissionId == permissionId);
            if (permission == null)
            {
                throw new RoleDomainException($"Permission {permissionId} is not assigned to role {this.Id}");
            }
            _rolePermissions.Remove(permission);
            this.ApplyEvent(new PermissionUnassignedEvent(this.Identity, this.Id, permissionId));
        }

        protected Role(Guid identity, string name, string code)
        {
            this.Identity = identity;
            this.Name = name;
            this.Code = code;
            _rolePermissions = new List<RolePermission>();
            this.ApplyEvent(new RoleCreatedEvent(identity, code, name));
        }

        protected Role()
        {

        }
    }
}
