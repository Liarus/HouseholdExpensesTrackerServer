using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Event
{
    public interface IDomainEventStore
    {
        Task Save(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<IDomainEvent>> Get(Guid aggregateId, int fromVersion,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
