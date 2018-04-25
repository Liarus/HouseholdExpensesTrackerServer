using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Event
{
    public interface IDomainEventDispatcher
    {
        Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken)) 
            where TEvent : IDomainEvent;
    }
}
