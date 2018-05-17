using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using HouseholdExpensesTrackerServer.Domain.Savings.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class SavingTypeRepository : EntityFrameworkRepository<SavingType, int>, ISavingTypeRepository
    {
        public SavingTypeRepository(IDbContext context) : base(context)
        {

        }
    }
}
