using HouseholdExpensesTrackerServer.Application.Core.Exception;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Application.Core.QueryHandler
{
    public class GetLastIdQueryHandler : IQueryHandlerAsync<GetLastIdQuery, int>
    {
        private readonly IDbContext _db;

        public GetLastIdQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<int> HandleAsync(GetLastIdQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var ids = _db.GetAllInsertedIds(query.EntityName);
            if (ids.Count == 0)
            {
                throw new GetLastIdQueryException($"No entity {query.EntityName} was inserted on current session");
            }
            return await Task.FromResult(ids.First());
        }
    }
}
