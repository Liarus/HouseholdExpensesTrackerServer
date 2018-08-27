using HouseholdExpensesTrackerServer.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Command
{
    public interface ICommandHandler<in T> : IMessageHandler<T> where T : ICommand
    {
    }
}
