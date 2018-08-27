using HouseholdExpensesTrackerServer.Application.Savings.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HouseholdExpensesTrackerServer.Common.Query;

namespace HouseholdExpensesTrackerServer.Application.Savings.QueryHandler
{
    public class SavingTypeQueryHandler : IQueryHandlerAsync<SavingTypeListQuery, IEnumerable<SavingTypeDto>>
    {
        private readonly IDbContext _db;

        public SavingTypeQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SavingTypeDto>> HandleAsync(SavingTypeListQuery query,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var types = await
                _db.SavingTypes
                    .Where(e => e.UserId == query.UserId)
                    .Select(e =>
                        new SavingTypeDto
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Symbol = e.Symbol,
                            Version = e.Version
                        }
                    ).AsNoTracking().ToListAsync(cancellationToken);
            return types;
        }
    }
}
