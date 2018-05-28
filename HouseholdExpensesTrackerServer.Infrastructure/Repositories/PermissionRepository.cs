using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.Identities.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class PermissionRepository : EntityFrameworkRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(IDbContext context) : base(context)
        {

        }
    }
}
