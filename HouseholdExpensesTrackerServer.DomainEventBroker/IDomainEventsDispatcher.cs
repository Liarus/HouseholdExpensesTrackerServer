using HouseholdExpensesTrackerServer.Domain.DomainSpecification.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.DomainEventBroker
{
    public interface IDomainEventsDispatcher
    {
        IContainerFacade Container { get; }

        void Raise<T>(T args) where T : IDomainEvent;

        void ClearCallbacks();
    }
}
