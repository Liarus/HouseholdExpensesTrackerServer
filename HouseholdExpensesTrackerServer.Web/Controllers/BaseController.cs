using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private readonly Lazy<ICommandDispatcherAsync> _commandDispatcher;

        private readonly Lazy<IQueryDispatcherAsync> _queryDispatcher;

        public BaseController(Lazy<ICommandDispatcherAsync> commandDispatcher,
            Lazy<IQueryDispatcherAsync> queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        protected async Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
            => await _commandDispatcher.Value.SendAsync<TCommand>(command, default(CancellationToken));

        protected async Task<TResult> GetQueryAsync<TResult>(IQuery query)
            => await _queryDispatcher.Value.ExecuteAsync<TResult>(query, default(CancellationToken));
    }
}