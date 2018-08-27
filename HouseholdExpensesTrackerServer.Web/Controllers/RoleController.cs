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
    [Route("api/Role")]
    public class RoleController : Controller
    {
        private readonly ICommandDispatcherAsync _commandDispatcher;

        private readonly IQueryDispatcherAsync _queryDispatcher;

        public RoleController(ICommandDispatcherAsync commandDispatcher,
                              IQueryDispatcherAsync queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _queryDispatcher.ExecuteAsync<IEnumerable<RoleDto>>(new RoleListQuery());
            return Ok(roles);
        }

        // POST: api/Role
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyRoleDto command)
        {
            await _commandDispatcher.SendAsync<ModifyRoleCommand>(new ModifyRoleCommand(command.Id,
           command.Name, command.Code, command.PermissionIds, command.Version));
            return Ok();
        }

        // POST: api/Role/5/assignPermission/2
        [HttpPost]
        [Route("~/api/role/{roleId:int}/assignPermission/{permissionId:int}")]
        public async Task<IActionResult> AssignPermission(int roleId, int permissionId)
        {
            await _commandDispatcher.SendAsync<AssignPermissionCommand>(
                new AssignPermissionCommand(permissionId, roleId));
            return Ok();
        }

        // POST: api/Role/5/assignPermission/2
        [HttpPost]
        [Route("~/api/role/{roleId:int}/unassignPermission/{permissionId:int}")]
        public async Task<IActionResult> UnAssignPermission(int roleId, int permissionId)
        {
            await _commandDispatcher.SendAsync<UnassignPermissionCommand>(
                new UnassignPermissionCommand(permissionId, roleId));
            return Ok();
        }

        // PUT: api/Role
        public async Task<IActionResult> Put([FromBody]CreateRoleDto command)
        {
            await _commandDispatcher.SendAsync<CreateRoleCommand>(new CreateRoleCommand(command.Name,
               command.Code, command.PermissionIds));
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _commandDispatcher.SendAsync<DeleteRoleCommand>(new DeleteRoleCommand(id));
            return Ok();
        }
    }
}
