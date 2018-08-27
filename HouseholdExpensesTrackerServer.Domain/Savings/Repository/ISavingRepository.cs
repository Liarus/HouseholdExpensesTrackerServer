using HouseholdExpensesTrackerServer.Common.Repository;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Repository
{
    public interface ISavingRepository : IRepository<Saving, int>
    {
    }
}
