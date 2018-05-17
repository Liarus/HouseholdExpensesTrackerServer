using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.Expenses.Repository;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class ExpenseTypeRepository : EntityFrameworkRepository<ExpenseType, int>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(IDbContext context) : base(context)
        {

        }
    }
}
