using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTO.Input.RoleDTO;
using Workshop.Domain.DTO.Output.Generic;
using Workshop.Domain.DTO.Output.RoleDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.RoleUseCases;

namespace Workshop.Api.Controllers;

using NotificationList = IReadOnlyCollection<Notification>;

[ApiController, Route("roles")]
public class RoleController : WorkshopBaseController
{
    [HttpGet, Authorize]
    public List<RoleResultDTO> GetRoles(
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var employee = employeeRepository.GetByUserId(GetUserId());
        var rolesList = roleRepository.GetAll(employee.CompanyId);

        var roles = new List<RoleResultDTO>();
        foreach ( var role in rolesList )
        {
            roles.Add(new RoleResultDTO(role));
        }

        return Ok(roles);
    }

    [HttpPost, Authorize]
    [ProducesResponseType(typeof(RoleResultDTO), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic CreateRole(
        [FromBody] CreateRoleDTO data,
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        [FromServices] IPermissionRepository permissionRepository 
    )
    {
        var result = new CreateRoleUseCase(employeeRepository, roleRepository, permissionRepository).Handle(data, GetUserId());

        return ParseResult(result);
    }

    [HttpPost("add"), Authorize]
    [ProducesResponseType(typeof(MessageResult), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic AddPermission(
        [FromBody] AddPermissionDTO data,
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        [FromServices] IPermissionRepository permissionRepository
    )
    {
        var result = new AddPermissionUseCase(employeeRepository, roleRepository, permissionRepository).Handle(data, GetUserId());

        return ParseResult(result);
    }

    [HttpDelete("{id}"), Authorize]
    [ProducesResponseType(typeof(MessageResult), 200)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic DeleteRole(
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        string id
    )
    {
        var result = new DeleteRoleUseCase(employeeRepository, roleRepository).Handle(new DeleteRoleDTO(Guid.Parse(id)), GetUserId());

        return ParseResult(result);
    }
}
