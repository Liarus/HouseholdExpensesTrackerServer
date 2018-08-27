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
    [Produces("application/json")]
    [Route("api/Permission")]
    public class PermissionController : Controller
    {
        private readonly ICommandDispatcherAsync _commandDispatcher;

        private readonly IQueryDispatcherAsync _queryDispatcher;

        public PermissionController(ICommandDispatcherAsync commandDispatcher,
                                    IQueryDispatcherAsync queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/Permission
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var permissions = await _queryDispatcher.ExecuteAsync<IEnumerable<PermissionDto>>(new PermissionListQuery());
            return Ok(permissions);
        }

        // POST: api/Permission
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyPermissionDto command)
        {
            await _commandDispatcher.SendAsync<ModifyPermissionCommand>(new ModifyPermissionCommand(command.Id,
            command.Name, command.Code, command.Version));
            return Ok();
        }

        // PUT: api/Permission
        public async Task<IActionResult> Put([FromBody]CreatePermissionDto command)
        {
            await _commandDispatcher.SendAsync<CreatePermissionCommand>(new CreatePermissionCommand(command.Name,
                command.Code));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandDispatcher.SendAsync<DeletePermissionCommand>(new DeletePermissionCommand(id));
            return Ok();
        }
    }
}
