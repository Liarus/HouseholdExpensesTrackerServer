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
    public class HouseholdCommandHandler : ICommandHandlerAsync<CreatePermissionCommand>,
                                           ICommandHandlerAsync<ModifyPermissionCommand>,
                                           ICommandHandlerAsync<DeletePermissionCommand>
    {
        private readonly IPermissionRepository _permissions;
        public HouseholdCommandHandler(IPermissionRepository permissions)
        {
            _permissions = permissions;
        }

        public async Task HandleAsync(CreatePermissionCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var permission = Permission.Create(Guid.NewGuid(), message.Name, message.Code);
            _permissions.Add(permission);
            await _permissions.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifyPermissionCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var permission = await this.GetPermission(message.PermissionId);
            permission.Modify(message.Name, message.Code, message.Version);
            await _permissions.SaveChangesAsync(token);
        }

        public async Task HandleAsync(DeletePermissionCommand message, CancellationToken token = default(CancellationToken))
        {
            var permission = await this.GetPermission(message.PermissionId, token);
            permission.Delete();
            _permissions.Delete(permission);
            await _permissions.SaveChangesAsync();
        }

        protected async Task<Permission> GetPermission(int permissionId, CancellationToken token = default(CancellationToken))
        {
            var permission = await _permissions.GetByIdAsync(permissionId, token);
            if (permission == null)
            {
                throw new PermissionCommandException($"Permission {permissionId} doesn't exists");
            }
            return permission;
        }
    }
}
