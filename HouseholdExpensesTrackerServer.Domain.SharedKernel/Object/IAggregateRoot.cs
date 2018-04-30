using HouseholdExpensesTrackerServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Object
{
    public interface IAggregateRoot
    {
        Guid Identity { get; }

        IReadOnlyCollection<IEvent> Events { get; }

        void ClearEvents();

        IEvent[] FlushUncommitedEvents();
    }
}
