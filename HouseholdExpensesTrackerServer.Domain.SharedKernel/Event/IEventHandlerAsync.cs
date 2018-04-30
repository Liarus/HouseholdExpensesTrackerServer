using HouseholdExpensesTrackerServer.Domain.SharedKernel.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Event
{
    public interface IEventHandlerAsync<in T> : IMessageHandlerAsync<T> where T: IEvent
    {
    }
}
