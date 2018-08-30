using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Application.Savings.Command;
using HouseholdExpensesTrackerServer.Application.Savings.Query;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    public class SavingTypeController : BaseController
    {
        public SavingTypeController(Lazy<ICommandDispatcherAsync> commandDispatcher,
            Lazy<IQueryDispatcherAsync> queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [Route("~/api/user/{userId:int}/savingTypes")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var result = await this.GetQueryAsync<IEnumerable<SavingTypeDto>>(new SavingTypeListQuery(userId));
            return Ok(result);
        }

        // POST: api/SavingType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateSavingTypeDto command)
        {
            await this.SendCommandAsync<CreateSavingTypeCommand>(new CreateSavingTypeCommand(command.UserId,
                command.Name, command.Symbol));
            var insertedId = await this.GetQueryAsync<int>(new GetLastIdQuery(nameof(SavingType)));
            return Ok(insertedId);
        }

        // PUT: api/SavingType
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ModifySavingTypeDto command)
        {
            await this.SendCommandAsync<ModifySavingTypeCommand>(new ModifySavingTypeCommand(command.Id,
               command.Name, command.Symbol, command.Version));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SendCommandAsync<DeleteSavingTypeCommand>(new DeleteSavingTypeCommand(id));
            return Ok();
        }
    }
}
