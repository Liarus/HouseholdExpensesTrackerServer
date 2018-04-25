using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Event
{
    public interface IDomainEventStore
    {
        Task Save(IEnumerable<IDomainEvent> events);

        Task<IEnumerable<IDomainEvent>> Get(IIdValue aggregateId, int fromVersion);
    }
}
