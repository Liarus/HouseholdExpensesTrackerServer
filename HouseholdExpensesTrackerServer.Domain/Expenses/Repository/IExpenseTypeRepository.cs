using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Expenses.Repository
{
    public interface IExpenseTypeRepository : IRepository<ExpenseType, int>
    {
    }
}
