using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Api.Adapters;
using Workshop.Domain.DTO.Input.CompanyDTO;
using Workshop.Domain.DTO.Output.CompanyDTO;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.CompanyUseCases;

namespace Workshop.Api.Controllers;

[ApiController]
[Route("company")]
public class CompanyController : ControllerBase
{
    [HttpGet, Authorize]
    public IActionResult GetCompany(
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var employee = employeeRepository.GetByUserId(Guid.Parse(User.Identity.Name));

        return new OkObjectResult(new CompanyResultDTO(employee.Company));
    }

    [HttpPost("create"), Authorize]
    public IActionResult CreateCompany(
        [FromBody] CreateCompanyDTO data,
        [FromServices] ICompanyRepository companyRepository,
        [FromServices] IUserRepository userRepository,
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository,
        [FromServices] IPermissionRepository permissionRepository
    )
    {
        var userId = User?.Identity?.Name;

        var result = new CreateCompanyUseCase(
            userRepository, 
            companyRepository, 
            roleRepository, 
            employeeRepository, 
            permissionRepository
        ).Handle(
            data, 
            Guid.Parse(userId)
        );

        return ResultAdapter.Parse(result);
    }

    [HttpPost("employee"), Authorize]
    public IActionResult AddEmployee(
        [FromBody] AddEmployeeDTO data,
        [FromServices] ICompanyRepository companyRepository,
        [FromServices] IUserRepository userRepository,
        [FromServices] IRoleRepository roleRepository,
        [FromServices] IEmployeeRepository employeeRepository
    )
    {
        var result = new AddEmployeeUseCase(userRepository, companyRepository, roleRepository, employeeRepository).Handle(data, Guid.Parse(User.Identity.Name));

        return ResultAdapter.Parse(result);
    }
}
