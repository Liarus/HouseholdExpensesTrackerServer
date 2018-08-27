using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Type;
using HouseholdExpensesTrackerServer.Application.Identities.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;

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
            var permission = await this.GetPermissionAsync(message.PermissionId);
            permission.Modify(message.Name, message.Code, message.Version);
            await _permissions.SaveChangesAsync(token);
        }

        public async Task HandleAsync(DeletePermissionCommand message, CancellationToken token = default(CancellationToken))
        {
            var permission = await this.GetPermissionAsync(message.PermissionId, token);
            permission.Delete();
            _permissions.Delete(permission);
            await _permissions.SaveChangesAsync();
        }

        protected async Task<Permission> GetPermissionAsync(int permissionId, CancellationToken token = default(CancellationToken))
        {
            var permission = await _permissions.GetByIdAsync(permissionId, token);
            if (permission == null)
            {
                throw new HouseholdException($"Permission {permissionId} doesn't exists");
            }
            return permission;
        }
    }
}
