﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using HouseholdExpensesTrackerServer.Domain.Identities.Event;
using HouseholdExpensesTrackerServer.Domain.Definitions.Object;
using HouseholdExpensesTrackerServer.Common.Type;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Model
{
    public class Role : AggregateRoot<int>
    {
        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public IReadOnlyCollection<RolePermission> RolePermissions => _rolePermissions;

        private readonly HashSet<RolePermission> _rolePermissions = new HashSet<RolePermission>();

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

        public void Delete()
        {
            this.ApplyEvent(new RoleDeletedEvent(this.Identity, this.Id));
        }

        public void AssignPermission(int permissionId)
        {
            var role = _rolePermissions.SingleOrDefault(e => e.PermissionId == permissionId);
            if (role != null)
            {
                throw new HouseholdException($"Permission {permissionId} is already assigned to role {this.Id}");
            }
            _rolePermissions.Add(new RolePermission { PermissionId = permissionId });
            this.ApplyEvent(new PermissionAssignedEvent(this.Identity, this.Id, permissionId));
        }

        public void UnassignPermission(int permissionId)
        {
            var permission = _rolePermissions.SingleOrDefault(e => e.PermissionId == permissionId);
            if (permission == null)
            {
                throw new HouseholdException($"Permission {permissionId} is not assigned to role {this.Id}");
            }
            _rolePermissions.Remove(permission);
            this.ApplyEvent(new PermissionUnassignedEvent(this.Identity, this.Id, permissionId));
        }

        public void UnassignAllPermissions()
        {
            foreach(var permission in _rolePermissions)
            {
                this.UnassignPermission(permission.PermissionId);
            }
        }

        protected Role(Guid identity, string name, string code)
        {
            this.Identity = identity;
            this.Name = name;
            this.Code = code;
            this.ApplyEvent(new RoleCreatedEvent(identity, code, name));
        }

        protected Role()
        {

        }
    }
}
