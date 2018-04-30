using Autofac;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseholdExpensesTrackerServer.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcherAsync
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var handlerType = 
                typeof(IQueryHandlerAsync<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler;
            if (_componentContext.TryResolve(handlerType, out handler))
            {
                return await handler.HandleAsync((dynamic)query, cancellationToken);
            }

            throw new HandlerNotFoundException(query.GetType().Name, nameof(QueryDispatcher));
        }

    }
}
