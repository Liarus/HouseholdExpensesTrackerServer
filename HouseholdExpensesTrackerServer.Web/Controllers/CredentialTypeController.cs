using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Identities.Command;
using HouseholdExpensesTrackerServer.Application.Identities.Query;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    public class CredentialTypeController : BaseController
    {
        public CredentialTypeController(ICommandDispatcherAsync commandDispatcher,
            IQueryDispatcherAsync queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        // GET: api/CredentialType
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.GetQueryAsync<IEnumerable<CredentialTypeDto>>(new CredentialTypeListQuery());
            return Ok(result);
        }

        // POST: api/CredentialType
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyCredentialTypeDto command)
        {
            await this.SendCommandAsync<ModifyCredentialTypeCommand>(new ModifyCredentialTypeCommand(command.Id,
             command.Name, command.Code, command.Version));
            return Ok();
        }

        // PUT: api/CredentialType
        public async Task<IActionResult> Put([FromBody]CreateCredentialTypeDto command)
        {
            await this.SendCommandAsync<CreateCredentialTypeCommand>(new CreateCredentialTypeCommand(command.Name,
                command.Code));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SendCommandAsync<DeleteCredentialTypeCommand>(new DeleteCredentialTypeCommand(id));
            return Ok();
        }
    }
}
