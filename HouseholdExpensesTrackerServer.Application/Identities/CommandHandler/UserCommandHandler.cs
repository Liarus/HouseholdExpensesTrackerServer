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
    public class UserCommandHandler : ICommandHandler<CreateUserCommand>,
                                      ICommandHandler<ModifyUserCommand>,
                                      ICommandHandler<AddCredentialCommand>,
                                      ICommandHandler<AssignRoleCommand>,
                                      ICommandHandler<UnassignRoleCommand>
    {
        IUserRepository _users;

        public UserCommandHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task Handle(CreateUserCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var user = User.Create(Guid.NewGuid(), message.Name);
            _users.Add(user);
            await _users.SaveChangesAsync(token);
        }

        public async Task Handle(ModifyUserCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUser(message.UserId);
            user.Modify(message.Name, message.RowVersion);
            await _users.SaveChangesAsync(token);
        }

        public async Task Handle(AddCredentialCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUser(message.UserId);
            user.AddCredential(Credential.Create(message.CredentialTypeId, 
                message.Identifier, message.Secret));
            await _users.SaveChangesAsync(token);
        }

        public async Task Handle(AssignRoleCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUser(message.UserId);
            user.AssignRole(message.RoleId);
            await _users.SaveChangesAsync(token);
        }

        public async Task Handle(UnassignRoleCommand message, 
            CancellationToken token = default(CancellationToken))
        {
            var user = await this.GetUser(message.UserId);
            user.UnassignRole(message.RoleId);
            await _users.SaveChangesAsync(token);
        }

        protected async Task<User> GetUser(int userId)
        {
            var user = await _users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new UserCommandException($"User {userId} doesn't exists");
            }
            return user;
        }
    }
}
