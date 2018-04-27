using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Domain.Identities.Repository
{
    public interface IPermissionRepository : IRepository<Permission, int>
    {
    }
}
