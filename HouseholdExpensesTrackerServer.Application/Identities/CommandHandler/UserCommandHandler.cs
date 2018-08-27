using HouseholdExpensesTrackerServer.Application.Identities.Command;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Type;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Identities.CommandHandler
{
    public class UserCommandHandler : ICommandHandlerAsync<CreateUserCommand>,
                                      ICommandHandlerAsync<ModifyUserCommand>,
                                      ICommandHandlerAsync<AddCredentialCommand>,
                                      ICommandHandlerAsync<AssignRoleCommand>,
                                      ICommandHandlerAsync<UnassignRoleCommand>
    {
        private readonly IUserRepository _users;

        public UserCommandHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task HandleAsync(CreateUserCommand message,
            CancellationToken token = default(CancellationToken))
        {
            var user = User.Create(Guid.NewGuid(), message.Name);
            _users.Add(user);
            await _users.SaveChangesAsync(token);
        }

        public async Task HandleAsync(ModifyUserCommand message,
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUserAsync(message.UserId, token);
            user.Modify(message.Name, message.Version);
            await _users.SaveChangesAsync(token);
        }

        public async Task HandleAsync(AddCredentialCommand message,
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUserAsync(message.UserId, token);
            user.AddCredential(Credential.Create(message.CredentialTypeId,
                message.Identifier, message.Secret));
            await _users.SaveChangesAsync(token);
        }

        public async Task HandleAsync(AssignRoleCommand message,
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUserAsync(message.UserId, token);
            user.AssignRole(message.RoleId);
            await _users.SaveChangesAsync(token);
        }

        public async Task HandleAsync(UnassignRoleCommand message,
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUserAsync(message.UserId, token);
            user.UnassignRole(message.RoleId);
            await _users.SaveChangesAsync(token);
        }

        protected async Task<User> GetUserAsync(int userId, CancellationToken token = default(CancellationToken))
        {
            var user = await _users.GetByIdAsync(userId, token);
            if (user == null)
            {
                throw new HouseholdException($"User {userId} doesn't exists");
            }
            return user;
        }
    }
}
