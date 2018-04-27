using HouseholdExpensesTrackerServer.Application.Identities.Exception;
using HouseholdExpensesTrackerServer.Domain.Identities.Command;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Identities.CommandHandler
{
    public class RoleCommandHandler : ICommandHandler<CreateRoleCommand>,
                                      ICommandHandler<ModifyRoleCommand>,
                                      ICommandHandler<AssignPermissionCommand>,
                                      ICommandHandler<UnassignPermissionCommand>
    {
        private readonly IRoleRepository _roles;

        public RoleCommandHandler(IRoleRepository roles)
        {
            _roles = roles;
        }

        public async Task Handle(CreateRoleCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var role = Role.Create(Guid.NewGuid(), message.Name, message.Code);
            _roles.Add(role);
            await _roles.SaveChangesAsync(token);
        }

        public async Task Handle(ModifyRoleCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var role = await this.GetRole(message.RoleId);
            role.Modify(message.Name, message.Code, message.RowVersion);
            await _roles.SaveChangesAsync(token);
        }

        public async Task Handle(AssignPermissionCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var role = await this.GetRole(message.RoleId);
            role.AssignPermission(message.PermissionId);
            await _roles.SaveChangesAsync(token);
        }

        public async Task Handle(UnassignPermissionCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var role = await this.GetRole(message.RoleId);
            role.UnassignPermission(message.PermissionId);
            await _roles.SaveChangesAsync(token);
        }

        protected async Task<Role> GetRole(int roleId)
        {
            var role = await _roles.GetByIdAsync(roleId);
            if (role == null)
            {
                throw new RoleCommandException($"Role {roleId} doesn't exists");
            }
            return role;
        }
    }
}
