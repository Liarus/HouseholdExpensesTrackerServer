using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Application.Savings.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Savings.Command;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/SavingType")]
    public class SavingTypeController : Controller
    {
        private readonly ICommandDispatcherAsync _commandDispatcher;

        private readonly IQueryDispatcherAsync _queryDispatcher;

        public SavingTypeController(ICommandDispatcherAsync commandDispatcher,
                                    IQueryDispatcherAsync queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/SavingType
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SavingType/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("~/api/user/{userId:int}/savingTypes")]
        public async Task<IActionResult> GetForUser(int userId)
        {
            var types = await _queryDispatcher.ExecuteAsync<IEnumerable<SavingTypeDto>>(new SavingTypeListQuery(userId));
            return Ok(types);
        }

        // POST: api/SavingType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifySavingTypeDto command)
        {
            await _commandDispatcher.SendAsync<ModifySavingTypeCommand>(new ModifySavingTypeCommand(command.Id,
                command.Name, command.Symbol, command.Version));
            return Ok();
        }
        
        // PUT: api/SavingType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]CreateSavingTypeDto command)
        {
            await _commandDispatcher.SendAsync<CreateSavingTypeCommand>(new CreateSavingTypeCommand(command.UserId,
                command.Name, command.Symbol));
            var insertedId = await _queryDispatcher.ExecuteAsync<int>(new GetLastIdQuery(nameof(SavingType)));
            return Ok(insertedId);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandDispatcher.SendAsync<DeleteSavingTypeCommand>(new DeleteSavingTypeCommand(id));
            return Ok();
        }
    }
}
