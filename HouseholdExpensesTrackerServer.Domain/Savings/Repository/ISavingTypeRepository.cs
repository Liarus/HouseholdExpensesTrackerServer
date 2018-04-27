using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Savings.Repository
{
    public interface ISavingTypeRepository : IRepository<SavingType, int>
    {
    }
}
