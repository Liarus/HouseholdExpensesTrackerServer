using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> Executec<TResult>(IQuery<TResult> query,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
