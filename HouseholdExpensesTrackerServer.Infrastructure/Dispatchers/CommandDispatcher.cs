using Autofac;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Type;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcherAsync
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task SendAsync<TCommand>(TCommand command,
            CancellationToken cancellationToken) where TCommand : ICommand
        {
            if (_componentContext.TryResolve(out ICommandHandlerAsync<TCommand> handler))
            {
                await handler.HandleAsync(command, cancellationToken);
            }
            else
            {
                throw new HouseholdException(
                     $"Hanlder for command: {command.GetType().Name} in dispatcher {nameof(CommandDispatcher)} has not been found");
            }
        }
    }
}
