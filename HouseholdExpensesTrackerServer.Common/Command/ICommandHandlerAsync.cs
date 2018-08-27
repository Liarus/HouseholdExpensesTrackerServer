using HouseholdExpensesTrackerServer.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Command
{
    public interface ICommandHandlerAsync<in T> : IMessageHandlerAsync<T> where T : ICommand
    {
    }
}
