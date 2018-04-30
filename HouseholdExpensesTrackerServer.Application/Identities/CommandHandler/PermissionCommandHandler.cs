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
                                           ICommandHandlerAsync<ModifyPermissionCommand>
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
            var permission = await _permissions.GetByIdAsync(message.PermissionId);
            if (permission == null)
            {
                throw new PermissionCommandException($"Permission {message.PermissionId} doesn't exists");
            }
            permission.Modify(message.Name, message.Code, message.RowVersion);
            await _permissions.SaveChangesAsync(token);
        }
    }
}
