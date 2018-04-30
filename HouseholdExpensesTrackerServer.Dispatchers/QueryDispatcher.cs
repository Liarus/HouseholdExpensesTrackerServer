using Autofac;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task<TResult> Execute<TResult>(IQuery query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var handlerType = 
                typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler;
            if (_componentContext.TryResolve(handlerType, out handler))
            {
                return await handler.Handle((dynamic)query, cancellationToken);
            }

            throw new HandlerNotFoundException(query.GetType().Name, nameof(QueryDispatcher));
        }

    }
}
