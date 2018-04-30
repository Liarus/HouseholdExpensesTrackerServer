using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Households.Query
{
    public class HouseholdListQuery : BaseQuery
    {
        public readonly int UserId;

        public HouseholdListQuery(int userId)
        {
            this.UserId = userId;
        }
    }
}
