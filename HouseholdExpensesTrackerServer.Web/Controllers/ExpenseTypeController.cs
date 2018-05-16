using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Application.Expenses.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Expenses.Command;
using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/ExpenseType")]
    public class ExpenseTypeController : Controller
    {

        private readonly ICommandDispatcherAsync _commandDispatcher;

        private readonly IQueryDispatcherAsync _queryDispatcher;

        public ExpenseTypeController(ICommandDispatcherAsync commandDispatcher,
                                    IQueryDispatcherAsync queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/ExpenseType
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExpenseType/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("~/api/user/{userId:int}/expenseTypes")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var types = await _queryDispatcher.ExecuteAsync<IEnumerable<ExpenseTypeDto>>(new ExpenseTypeListQuery(userId));
            return Ok(types);
        }

        // POST: api/ExpenseType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyExpenseTypeDto command)
        {
            await _commandDispatcher.SendAsync<ModifyExpenseTypeCommand>(new ModifyExpenseTypeCommand(command.Id,
              command.Name, command.Symbol, command.Version));
            return Ok();
        }
        
        // PUT: api/ExpenseType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]CreateSavingTypeDto command)
        {
            await _commandDispatcher.SendAsync<CreateExpenseTypeCommand>(new CreateExpenseTypeCommand(command.UserId,
               command.Name, command.Symbol));
            var insertedId = await _queryDispatcher.ExecuteAsync<int>(new GetLastIdQuery(nameof(ExpenseType)));
            return Ok(insertedId);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandDispatcher.SendAsync<DeleteExpenseTypeCommand>(new DeleteExpenseTypeCommand(id));
            return Ok();
        }
    }
}
