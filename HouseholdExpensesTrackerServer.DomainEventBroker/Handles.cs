using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DomainEventBroker
{
    public interface Handles<T> where T: IDomainEvent
    {
        void Handle(T args);
    }
}
