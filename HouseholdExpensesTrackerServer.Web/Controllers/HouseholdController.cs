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
    public class HouseholdController : BaseController
    {
        public HouseholdController(Lazy<ICommandDispatcherAsync> commandDispatcher,
            Lazy<IQueryDispatcherAsync> queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [Route("~/api/user/{userId:int}/households")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var result = await this.GetQueryAsync<IEnumerable<HouseholdDto>>(new HouseholdListQuery(userId));
            return Ok(result);
        }

        // POST: api/Household
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyHouseholdDto request)
        {
            await this.SendCommandAsync<ModifyHouseholdCommand>(new ModifyHouseholdCommand(request.Id, request.Name,
                request.Symbol, request.Description, request.Street, request.City, request.Country, request.ZipCode,
                request.Version));
            return Ok();
        }

        // PUT: api/Household
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateHouseholdDto request)
        {
            await this.SendCommandAsync<CreateHouseholdCommand>(new CreateHouseholdCommand(request.UserId, request.Name,
                request.Symbol, request.Description, request.Street, request.City, request.Country, request.ZipCode));
            var insertedId = await this.GetQueryAsync<int>(new GetLastIdQuery(nameof(Household)));
            return Ok(insertedId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SendCommandAsync<DeleteHouseholdCommand>(new DeleteHouseholdCommand(id));
            return Ok();
        }
    }
}
