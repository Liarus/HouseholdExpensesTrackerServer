using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Households.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Command;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Households.Command;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Household/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("~/api/user/{userId:int}/households")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var housedolds = await _queryDispatcher.ExecuteAsync<IEnumerable<HouseholdDto>>(new HouseholdListQuery(userId));
            return Ok(housedolds);
        }
        
        // POST: api/Household
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Household/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CreateHouseholdDto request)
        {
            await _commandDispatcher.SendAsync<CreateHouseholdCommand>(new CreateHouseholdCommand(request.UserId, request.Name, 
                request.Symbol, request.Description, request.Street, request.City, request.Country, request.ZipCode));
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
