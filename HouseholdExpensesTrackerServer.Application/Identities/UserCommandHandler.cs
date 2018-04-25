using HouseholdExpensesTrackerServer.Domain.Identities.Command;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Identities
{
    public class UserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _users;

        public UserCommandHandler(IUserRepository users)
        {
            _users = users;
        }

        public async Task Handle(CreateUserCommand message, CancellationToken token = default(CancellationToken))
        {
            var user = User.Create(message.AggregateId, message.Name);
            _users.Add(user);
            await _users.SaveChangesAsync();
        }
    }
}
