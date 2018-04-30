using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands
{
    public interface ICommandDispatcherAsync
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) 
            where TCommand : ICommand;
    }
}
