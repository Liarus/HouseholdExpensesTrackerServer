using HouseholdExpensesTrackerServer.Application.Core.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Savings.Query
{
    public class SavingTypeListQuery : BaseQuery
    {
        public readonly int UserId;

        public SavingTypeListQuery(int userId)
        {
            this.UserId = userId;
        }
    }
}
