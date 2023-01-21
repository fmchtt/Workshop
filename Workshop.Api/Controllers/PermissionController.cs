using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Api.Controllers;

[ApiController, Route("permissions")]
public class PermissionController : WorkshopBaseController
{
    [HttpGet, Authorize]
    public List<Permission> GetPermissions([FromServices] IPermissionRepository permissionRepository)
    {
        return permissionRepository.GetAll();
    }
}
