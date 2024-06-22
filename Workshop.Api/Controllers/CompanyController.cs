using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Management.Companies.AddEmployee;
using Workshop.Application.Management.Companies.Create;
using Workshop.Application.Management.Companies.GetById;
using Workshop.Application.Results.Management;

namespace Workshop.Api.Controllers;

[ApiController, Route("company")]
public class CompanyController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet, Authorize]
    public async Task<CompanyResult> GetCompany()
    {
        var user = await GetUser();
        var query = new GetCompanyByIdQuery { CompanyId = user.Employee.CompanyId };
        return _mapper.Map<CompanyResult>(await _mediator.Send(query));
    }

    [HttpPost(), Authorize]
    public async Task<CompanyResult> CreateCompany(
        [FromBody] CreateCompanyCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<CompanyResult>(await _mediator.Send(command));
    }

    [HttpPost("employee"), Authorize]
    public async Task<EmployeeResult> AddEmployee(
        [FromBody] CreateEmployeeCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<EmployeeResult>(await _mediator.Send(command));
    }
}
