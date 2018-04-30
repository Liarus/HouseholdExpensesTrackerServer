using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Households.Repository;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpensesTrackerServer.Application.Households.Query
{
    public class HouseholdQueryHandler : IQueryHandler<HouseholdListQuery, IEnumerable<HouseholdDto>>
    {
        IDbContext _db;

        public HouseholdQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<HouseholdDto>> Handle(HouseholdListQuery query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var housesolds = await
                    _db.Households
                        .Where(e => e.UserId == query.UserId)
                        .Select(e =>
                            new HouseholdDto
                            {
                                Id = e.Id,
                                City = e.Address.City,
                                Country = e.Address.Country,
                                Description = e.Description,
                                Name = e.Name,
                                Street = e.Address.Street,
                                Symbol = e.Symbol,
                                ZipCode = e.Address.ZipCode,
                                RowVersion = string.Empty
                            }
                        ).AsNoTracking().ToListAsync();
            return housesolds;
        }
    }
}
