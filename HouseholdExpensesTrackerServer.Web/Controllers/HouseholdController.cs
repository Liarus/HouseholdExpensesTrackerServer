using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Application.Core.QueryHandler;
using HouseholdExpensesTrackerServer.Application.Households.Command;
using HouseholdExpensesTrackerServer.Application.Households.Query;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Command;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Households.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HouseholdController : Controller
    {

        private readonly ICommandDispatcherAsync _commandDispatcher;

        private readonly IQueryDispatcherAsync _queryDispatcher;

        public HouseholdController(ICommandDispatcherAsync commandDispatcher,
            IQueryDispatcherAsync queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [Route("~/api/user/{userId:int}/households")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var housedolds = await _queryDispatcher.ExecuteAsync<IEnumerable<HouseholdDto>>(new HouseholdListQuery(userId));
            return Ok(housedolds);
        }

        // POST: api/Household
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyHouseholdDto request)
        {
            await _commandDispatcher.SendAsync<ModifyHouseholdCommand>(new ModifyHouseholdCommand(request.Id, request.Name,
                request.Symbol, request.Description, request.Street, request.City, request.Country, request.ZipCode,
                request.Version));
            return Ok();
        }

        // PUT: api/Household
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateHouseholdDto request)
        {
            await _commandDispatcher.SendAsync<CreateHouseholdCommand>(new CreateHouseholdCommand(request.UserId, request.Name,
                request.Symbol, request.Description, request.Street, request.City, request.Country, request.ZipCode));
            var insertedId = await _queryDispatcher.ExecuteAsync<int>(new GetLastIdQuery(nameof(Household)));
            return Ok(insertedId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandDispatcher.SendAsync<DeleteHouseholdCommand>(new DeleteHouseholdCommand(id));
            return Ok();
        }
    }
}
