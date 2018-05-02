using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Application.Core.Query
{
    public class GetLastIdQuery : BaseQuery
    {
        public readonly string EntityName;

        public GetLastIdQuery(string entityName)
        {
            this.EntityName = entityName;
        }
    }
}
