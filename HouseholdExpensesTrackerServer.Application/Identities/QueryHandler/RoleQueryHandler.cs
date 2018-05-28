﻿using HouseholdExpensesTrackerServer.Application.Identities.Query;
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
    public class RoleQueryHandler : IQueryHandlerAsync<RoleListQuery, IEnumerable<RoleDto>>
    {
        private readonly IDbContext _db;

        public RoleQueryHandler(IDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RoleDto>> HandleAsync(RoleListQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var roles = await
                _db.Roles.Select(e => new RoleDto
                {
                    Id = e.Id,
                    Code = e.Code,
                    Name = e.Name,
                    PermissionIds = e.RolePermissions.Select(o => o.PermissionId).ToList()
                }).AsNoTracking().ToListAsync();
            return roles;
        }
    }
}