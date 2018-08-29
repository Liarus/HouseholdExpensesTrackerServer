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
    public class PermissionController : BaseController
    {
        public PermissionController(Lazy<ICommandDispatcherAsync> commandDispatcher,
            Lazy<IQueryDispatcherAsync> queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        // GET: api/Permission
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.GetQueryAsync<IEnumerable<PermissionDto>>(new PermissionListQuery());
            return Ok(result);
        }

        // POST: api/Permission
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyPermissionDto command)
        {
            await this.SendCommandAsync<ModifyPermissionCommand>(new ModifyPermissionCommand(command.Id,
            command.Name, command.Code, command.Version));
            return Ok();
        }

        // PUT: api/Permission
        public async Task<IActionResult> Put([FromBody]CreatePermissionDto command)
        {
            await this.SendCommandAsync<CreatePermissionCommand>(new CreatePermissionCommand(command.Name,
                command.Code));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SendCommandAsync<DeletePermissionCommand>(new DeletePermissionCommand(id));
            return Ok();
        }
    }
}
