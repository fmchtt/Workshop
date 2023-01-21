using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTO.Output.Generic;
using Workshop.Domain.DTO.Input.CompanyDTO;
using Workshop.Domain.DTO.Output.CompanyDTO;
using Workshop.Domain.DTO.Output.EmployeeDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.CompanyUseCases;

namespace Workshop.Api.Controllers;

using NotificationList = IReadOnlyCollection<Notification>;

[ApiController, Route("company")]
public class CompanyController : WorkshopBaseController
{
    [HttpGet, Authorize]
    public CompanyResultDTO GetCompany(
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var employee = employeeRepository.GetByUserId(GetUserId());

        return Ok(new CompanyResultDTO(employee.Company));
    }

    [HttpPost("create"), Authorize]
    [ProducesResponseType(typeof(CompanyResultDTO), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic CreateCompany(
        [FromBody] CreateCompanyDTO data,
        [FromServices] ICompanyRepository companyRepository,
        [FromServices] IUserRepository userRepository,
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        [FromServices] IPermissionRepository permissionRepository
    )
    {
        var result = new CreateCompanyUseCase(
            userRepository, 
            companyRepository, 
            roleRepository, 
            employeeRepository, 
            permissionRepository
        ).Handle(
            data, 
            GetUserId()
        );

        return ParseResult(result);
    }

    [HttpPost("employee"), Authorize]
    [ProducesResponseType(typeof(EmployeeResultDTO), 200)]
    [ProducesResponseType(typeof(NotificationList), 400)]
    [ProducesResponseType(typeof(MessageResult), 401)]
    [ProducesResponseType(typeof(MessageResult), 404)]
    public dynamic AddEmployee(
        [FromBody] AddEmployeeDTO data,
        [FromServices] ICompanyRepository companyRepository,
        [FromServices] IUserRepository userRepository,
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var result = new AddEmployeeUseCase(
            userRepository, 
            companyRepository, 
            roleRepository, 
            employeeRepository
        ).Handle(data, GetUserId());

        return ParseResult(result);
    }
}
