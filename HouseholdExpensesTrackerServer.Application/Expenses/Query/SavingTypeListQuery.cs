using HouseholdExpensesTrackerServer.Application.Core.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Expenses.Query
{
    public class ExpenseTypeListQuery : BaseQuery
    {
        public readonly int UserId;

        public ExpenseTypeListQuery(int userId)
        {
            this.UserId = userId;
        }
    }
}
