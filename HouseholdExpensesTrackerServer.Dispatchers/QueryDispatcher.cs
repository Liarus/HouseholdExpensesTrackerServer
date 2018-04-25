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

        public async Task<TResult> Executec<TResult>(IQuery<TResult> query, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var asyncGenericType = typeof(IQueryHandler<,>);
            var closedAsyncGeneric = asyncGenericType.MakeGenericType(query.GetType(), typeof(TResult));
            object asyncHandler;
            if (_componentContext.TryResolve(closedAsyncGeneric, out asyncHandler))
            {
                var result = asyncHandler
                    .GetType()
                    .GetMethod("Handle", new[] { query.GetType(), typeof(CancellationToken) })
                    .Invoke(asyncHandler, new object[] { query, cancellationToken });

                return await (Task<TResult>)result;
            }

            throw new HandlerNotFoundException(query.GetType().Name, nameof(QueryDispatcher));
        }

    }
}
