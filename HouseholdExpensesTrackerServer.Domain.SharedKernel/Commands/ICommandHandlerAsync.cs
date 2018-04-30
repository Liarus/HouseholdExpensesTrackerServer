using HouseholdExpensesTrackerServer.Domain.SharedKernel.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands
{
    public interface ICommandHandlerAsync<in T> : IMessageHandlerAsync<T> where T : ICommand
    {
    }
}
