using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using HouseholdExpensesTrackerServer.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class CredentialTypeRepository : EntityFrameworkRepository<CredentialType, int>
    {
        public CredentialTypeRepository(IDbContext context) : base(context)
        {

        }
    }
}
