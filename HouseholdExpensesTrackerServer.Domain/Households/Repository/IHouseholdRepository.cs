using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Households.Repository
{
    public interface IHouseholdRepository : IRepository<Household, int>
    {
    }
}
