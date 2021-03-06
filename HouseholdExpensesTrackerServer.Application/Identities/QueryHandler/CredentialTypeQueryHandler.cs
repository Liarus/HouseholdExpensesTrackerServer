﻿using HouseholdExpensesTrackerServer.Application.Identities.Query;
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

namespace HouseholdExpensesTrackerServer.Application.Identities.QueryHandler
{
    public class CredentialTypeQueryHandler : IQueryHandlerAsync<CredentialTypeListQuery, IEnumerable<CredentialTypeDto>>
    {
        private readonly IDbContext _db;

        public CredentialTypeQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CredentialTypeDto>> HandleAsync(CredentialTypeListQuery query,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var types = await
                _db.CredentialTypes
                    .Select(e =>
                        new CredentialTypeDto
                        {
                            Id = e.Id,
                            Code = e.Code,
                            Name = e.Name
                        }
                    ).AsNoTracking().ToListAsync();
            return types;
        }
    }
}
