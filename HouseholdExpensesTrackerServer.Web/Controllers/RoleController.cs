using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdExpensesTrackerServer.Application.Core.Query;
using HouseholdExpensesTrackerServer.Application.Identities.Command;
using HouseholdExpensesTrackerServer.Application.Identities.Query;
using HouseholdExpensesTrackerServer.Common.Command;
using HouseholdExpensesTrackerServer.Common.Query;
using HouseholdExpensesTrackerServer.DataTransferObjects.Request;
using HouseholdExpensesTrackerServer.DataTransferObjects.Response;
using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseholdExpensesTrackerServer.Web.Controllers
{
    public class RoleController : BaseController
    {
        public RoleController(Lazy<ICommandDispatcherAsync> commandDispatcher,
            Lazy<IQueryDispatcherAsync> queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        // GET: api/Role
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.GetQueryAsync<IEnumerable<RoleDto>>(new RoleListQuery());
            return Ok(result);
        }

        // POST: api/Role
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ModifyRoleDto command)
        {
            await this.SendCommandAsync<ModifyRoleCommand>(new ModifyRoleCommand(command.Id,
                command.Name, command.Code, command.PermissionIds, command.Version));
            return Ok();
        }

        // POST: api/Role/5/assignPermission/2
        [HttpPost]
        [Route("~/api/role/{roleId:int}/assignPermission/{permissionId:int}")]
        public async Task<IActionResult> AssignPermission(int roleId, int permissionId)
        {
            await this.SendCommandAsync<AssignPermissionCommand>(
                new AssignPermissionCommand(permissionId, roleId));
            return Ok();
        }

        // POST: api/Role/5/assignPermission/2
        [HttpPost]
        [Route("~/api/role/{roleId:int}/unassignPermission/{permissionId:int}")]
        public async Task<IActionResult> UnAssignPermission(int roleId, int permissionId)
        {
            await this.SendCommandAsync<UnassignPermissionCommand>(
                new UnassignPermissionCommand(permissionId, roleId));
            return Ok();
        }

        // PUT: api/Role
        public async Task<IActionResult> Put([FromBody]CreateRoleDto command)
        {
            await this.SendCommandAsync<CreateRoleCommand>(new CreateRoleCommand(command.Name,
               command.Code, command.PermissionIds));
            var insertedId = await this.GetQueryAsync<int>(new GetLastIdQuery(nameof(Role)));
            return Ok(insertedId);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.SendCommandAsync<DeleteRoleCommand>(new DeleteRoleCommand(id));
            return Ok();
        }
    }
}
