﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Domain.SharedKernel.Query
{
    public interface IQueryHandler<TQuery, TResult>  where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }
}
