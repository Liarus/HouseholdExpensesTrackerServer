using HouseholdExpensesTrackerServer.Domain.SharedKernel.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Event
{
    public interface IEventHandler<in T> : IMessageHandler<T> where T: IEvent
    {
    }
}
