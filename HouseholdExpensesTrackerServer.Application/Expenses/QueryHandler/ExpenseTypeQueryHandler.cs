using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HouseholdExpensesTrackerServer.Application.Expenses.Query;

namespace HouseholdExpensesTrackerServer.Application.Expenses.QueryHandler
{
    public class ExpenseTypeQueryHandler : IQueryHandlerAsync<ExpenseTypeListQuery, IEnumerable<ExpenseTypeDto>>
    {
        private readonly IDbContext _db;

        public ExpenseTypeQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ExpenseTypeDto>> HandleAsync(ExpenseTypeListQuery query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var types = await
                _db.ExpenseTypes
                    .Where(e => e.UserId == query.UserId)
                    .Select(e =>
                        new ExpenseTypeDto
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
