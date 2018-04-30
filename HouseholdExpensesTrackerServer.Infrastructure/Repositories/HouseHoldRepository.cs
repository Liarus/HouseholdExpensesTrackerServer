using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Households.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class HouseholdRepository : EntityFrameworkRepository<Household, int>, IHouseholdRepository
    {
        public HouseholdRepository(IDbContext context) : base(context)
        {

        }
    }
}
