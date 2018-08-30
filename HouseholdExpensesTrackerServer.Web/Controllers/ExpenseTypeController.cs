using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Application.Expenses.Command;
using HouseholdExpensesTrackerServer.Application.Expenses.Query;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Expenses.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    public class ExpenseTypeController : BaseController
    {
        public ExpenseTypeController(Lazy<ICommandDispatcherAsync> commandDispatcher,
            Lazy<IQueryDispatcherAsync> queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [Route("~/api/user/{userId:int}/expenseTypes")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var result = await this.GetQueryAsync<IEnumerable<ExpenseTypeDto>>(new ExpenseTypeListQuery(userId));
            return Ok(result);
        }

        // POST: api/ExpenseType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateExpenseTypeDto command)
        {
            await this.SendCommandAsync<CreateExpenseTypeCommand>(new CreateExpenseTypeCommand(command.UserId,
               command.Name, command.Symbol));
            var insertedId = await this.GetQueryAsync<int>(new GetLastIdQuery(nameof(ExpenseType)));
            return Ok(insertedId);
        }

        // PUT: api/ExpenseType
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ModifyExpenseTypeDto command)
        {
            await this.SendCommandAsync<ModifyExpenseTypeCommand>(new ModifyExpenseTypeCommand(command.Id,
              command.Name, command.Symbol, command.Version));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SendCommandAsync<DeleteExpenseTypeCommand>(new DeleteExpenseTypeCommand(id));
            return Ok();
        }
    }
}
