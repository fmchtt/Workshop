using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Management.Roles.Create;
using Workshop.Application.Management.Roles.CreatePermission;
using Workshop.Application.Management.Roles.GetRoles;
using Workshop.Application.Results.Management;
using Workshop.Domain.Entities.Management;

namespace Workshop.Api.Controllers;

[ApiController, Route("roles"), Authorize]
public class RoleController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet]
    public async Task<ICollection<RoleResult>> GetRoles()
    {
        var user = await GetUser();
        var query = new GetRolesQuery
        {
            CompanyId = user.Employee.CompanyId
        };
        return _mapper.Map<ICollection<RoleResult>>(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<RoleResult> CreateRole(
        [FromBody] CreateRoleCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<Role, RoleResult>(await _mediator.Send(command));
    }

    [HttpPost("permission")]
    public async Task<RoleResult> AddPermission(
        [FromBody] CreatePermissionCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<Role, RoleResult>(await _mediator.Send(command));
    }
}
