using HouseholdExpensesTrackerServer.Application.Identities.Query;
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

namespace HouseholdExpensesTrackerServer.Application.Identities.QueryHandler
{
    public class PermissionQueryHandler : IQueryHandlerAsync<PermissionListQuery, IEnumerable<PermissionDto>>
    {
        private readonly IDbContext _db;

        public PermissionQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PermissionDto>> HandleAsync(PermissionListQuery query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var permissions = await
                _db.Permissions
                    .Select(e =>
                        new PermissionDto
                        {
                            Id = e.Id,
                            Code = e.Code,
                            Name = e.Name
                        }
                    ).AsNoTracking().ToListAsync();
            return permissions;
        }
    }
}
