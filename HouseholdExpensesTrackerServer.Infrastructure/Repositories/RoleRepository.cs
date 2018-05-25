using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class RoleRepository : EntityFrameworkRepository<Role, int>
    {
        public RoleRepository(IDbContext context) : base(context)
        {

        }
    }
}
