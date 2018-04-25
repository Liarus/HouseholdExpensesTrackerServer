using Autofac;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task Send<TCommand>(TCommand command, 
            CancellationToken cancellationToken) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler;

            if (_componentContext.TryResolve(out handler))
            {
                await handler.Handle(command, cancellationToken);
            }
            else
            {
                throw new HandlerNotFoundException(command.GetType().Name, nameof(CommandDispatcher));
            }
        }
    }
}
