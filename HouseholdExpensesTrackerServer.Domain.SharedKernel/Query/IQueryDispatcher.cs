using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Query
{
    public interface IQueryDispatcher
    {
        Task<TResult> Execute<TResult>(IQuery query,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
