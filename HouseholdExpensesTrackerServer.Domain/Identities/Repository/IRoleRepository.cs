using HouseholdExpensesTrackerServer.Common.Repository;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Repository
{
    public interface IRoleRepository : IRepository<Role, int>
    {
    }
}
