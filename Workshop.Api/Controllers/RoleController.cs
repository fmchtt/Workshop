using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Management.Roles.Create;
using Workshop.Application.Management.Roles.CreatePermission;
using Workshop.Application.Management.Roles.Delete;
using Workshop.Application.Management.Roles.DeletePermission;
using Workshop.Application.Management.Roles.GetById;
using Workshop.Application.Management.Roles.GetPermissions;
using Workshop.Application.Management.Roles.GetRoles;
using Workshop.Application.Management.Roles.Update;
using Workshop.Application.Results;
using Workshop.Application.Results.Management;

namespace Workshop.Api.Controllers;

[ApiController, Route("roles"), Authorize]
public class RoleController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet]
    public async Task<ICollection<RoleResult>> GetRoles()
    {
        var query = new GetRolesQuery
        {
            Actor = await GetUser()
        };
        return _mapper.Map<ICollection<RoleResult>>(await _mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<RoleResult> GetRoleById([FromRoute] Guid id)
    {
        var query = new GetRoleByIdQuery
        {
            RoleId = id,
            Actor = await GetUser()
        };
        return _mapper.Map<RoleResult>(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<RoleResult> CreateRole(
        [FromBody] CreateRoleCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<RoleResult>(await _mediator.Send(command));
    }

    [HttpPatch("{id}")]
    public async Task<RoleResult> UpdateRole(
        [FromRoute] Guid id,
        [FromBody] UpdateRoleCommand command
    )
    {
        command.Actor = await GetUser();
        command.RoleId = id;
        return _mapper.Map<RoleResult>(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<MessageResult> DeleteRole(
        [FromRoute] Guid id
    )
    {
        var command = new DeleteRoleCommand { RoleId = id, Actor = await GetUser() };
        return new MessageResult(await _mediator.Send(command));
    }

    [HttpGet("permissions")]
    public async Task<Dictionary<string, List<string>>> GetPermissions()
    {
        var query = new GetAllPermissionsQuery();
        return await _mediator.Send(query);
    }

    [HttpPost("{id}/permission")]
    public async Task<RoleResult> AddPermission(
        [FromRoute] Guid id,
        [FromBody] CreatePermissionCommand command
    )
    {
        command.Actor = await GetUser();
        command.RoleId = id;
        return _mapper.Map<RoleResult>(await _mediator.Send(command));
    }

    [HttpPost("{id}/permission/remove")]
    public async Task<MessageResult> RemovePermission(
        [FromRoute] Guid id,
        [FromBody] DeletePermissionCommand command
    )
    {
        command.Actor = await GetUser();
        command.RoleId = id;
        return new MessageResult(await _mediator.Send(command));
    }
}
