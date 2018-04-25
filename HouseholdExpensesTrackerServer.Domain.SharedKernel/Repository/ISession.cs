using HouseholdExpensesTrackerServer.Domain.SharedKernel.Object;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository
{
    public interface ISession
    {
        Task Add<T>(T aggregate, CancellationToken 
            cancellationToken = default(CancellationToken)) where T : AggregateRoot;

        Task<T> Get<T>(Guid id, int? expectedVersion = null, 
            CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot;

        Task Commit(CancellationToken cancellationToken = default(CancellationToken));
    }
}
