using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Repositories
{
    public class Includes<TModel>
    {
        public Includes(Func<IQueryable<TModel>, IQueryable<TModel>> expression)
        {
            Expression = expression;
        }

        public Func<IQueryable<TModel>, IQueryable<TModel>> Expression { get; private set; }

    }
}
