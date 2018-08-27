using HouseholdExpensesTrackerServer.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Event
{
    public interface IEventHandlerAsync<in T> : IMessageHandlerAsync<T> where T: IEvent
    {
    }
}
