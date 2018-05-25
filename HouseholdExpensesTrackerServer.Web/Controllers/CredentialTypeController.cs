using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Identities.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Identities.Command;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Commands;
using HouseholdExpensesTrackerServer.Domain.SharedKernel.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/CredentialType")]
    public class CredentialTypeController : Controller
    {
        private readonly ICommandDispatcherAsync _commandDispatcher;

        private readonly IQueryDispatcherAsync _queryDispatcher;

        public CredentialTypeController(ICommandDispatcherAsync commandDispatcher,
                                        IQueryDispatcherAsync queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/CredentialType
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var types = await _queryDispatcher.ExecuteAsync<IEnumerable<CredentialTypeDto>>(new CredentialTypeListQuery());
            return Ok(types);
        }
        
        // POST: api/CredentialType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyCredentialTypeDto command)
        {
            await _commandDispatcher.SendAsync<ModifyCredentialTypeCommand>(new ModifyCredentialTypeCommand(command.Id,
             command.Name, command.Code, command.Version));
            return Ok();
        }
        
        // PUT: api/CredentialType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody]CreateCredentialTypeDto command)
        {
            await _commandDispatcher.SendAsync<CreateCredentialTypeCommand>(new CreateCredentialTypeCommand(command.Name,
                command.Code));
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandDispatcher.SendAsync<DeleteCredentialTypeCommand>(new DeleteCredentialTypeCommand(id));
            return Ok();
        }
    }
}
