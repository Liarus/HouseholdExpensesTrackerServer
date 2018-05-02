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
    public class CredentialTypeCommandHandler : ICommandHandlerAsync<CreateCredentialTypeCommand>,
                                                ICommandHandlerAsync<ModifyCredentialTypeCommand>
    {
        private readonly ICredentialTypeRepository _types;

        public CredentialTypeCommandHandler(ICredentialTypeRepository types)
        {
            _types = types;
        }

        public async Task HandleAsync(CreateCredentialTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = CredentialType.Create(Guid.NewGuid(), message.Name, message.Code);
            _types.Add(type);
            await _types.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifyCredentialTypeCommand message, CancellationToken token = default(CancellationToken))
        {
            var type = await _types.GetByIdAsync(message.CredentialTypeId);
            if (type == null)
            {
                throw new CredentialTypeCommandException(
                    $"Credential Type {message.CredentialTypeId} doesn't exists");
            }
            type.Modify(message.Name, message.Code, message.Version);
            await _types.SaveChangesAsync(token);
        }
    }
}
