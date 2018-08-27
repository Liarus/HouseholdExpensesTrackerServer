using HouseholdExpensesTrackerServer.Common.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Common.Object
{
    public interface IAggregateRoot
    {
        Guid Identity { get; }

        IReadOnlyCollection<IEvent> Events { get; }

        void ClearEvents();

        IEvent[] FlushUncommitedEvents();
    }
}
