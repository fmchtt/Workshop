using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Application.Management.Companies.AddEmployee;
using Workshop.Application.Management.Companies.ChangeCompany;
using Workshop.Application.Management.Companies.Create;
using Workshop.Application.Management.Companies.Delete;
using Workshop.Application.Management.Companies.GetAll;
using Workshop.Application.Management.Companies.GetById;
using Workshop.Application.Management.Companies.GetEmployees;
using Workshop.Application.Management.Companies.RemoveEmployee;
using Workshop.Application.Management.Companies.Update;
using Workshop.Application.Results;
using Workshop.Application.Results.Management;

namespace Workshop.Api.Controllers;

[ApiController, Route("company"), Authorize]
public class CompanyController(IMediator mediator, IMapper mapper) : WorkshopBaseController(mediator, mapper)
{
    [HttpGet("active")]
    public async Task<CompanyResult> GetCompany()
    {
        var user = await GetUser();
        var query = new GetCompanyByIdQuery { CompanyId = user.Employee?.CompanyId ?? Guid.Empty };
        return _mapper.Map<CompanyResult>(await _mediator.Send(query));
    }

    [HttpGet]
    public async Task<ICollection<CompanyResult>> GetAllCompanies()
    {
        var query = new GetAllCompaniesQuery { Actor = await GetUser() };
        return _mapper.Map<ICollection<CompanyResult>>(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<CompanyResult> CreateCompany(
        [FromBody] CreateCompanyCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<CompanyResult>(await _mediator.Send(command));
    }

    [HttpPatch("{id}")]
    public async Task<CompanyResult> UpdateCompany(
        [FromRoute] Guid id,
        [FromBody] UpdateCompanyCommand command
    )
    {
        command.Actor = await GetUser();
        command.CompanyId = id;
        return _mapper.Map<CompanyResult>(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<MessageResult> DeleteCompany(
        [FromRoute] Guid id
    )
    {
        var command = new DeleteCompanyCommand { CompanyId = id, Actor = await GetUser() };
        return new MessageResult(await _mediator.Send(command));
    }

    [HttpGet("employee")]
    public async Task<ICollection<EmployeeResult>> GetEmployees()
    {
        var query = new GetAllEmployeesQuery { Actor = await GetUser() };
        return _mapper.Map<ICollection<EmployeeResult>>(await _mediator.Send(query));
    }

    [HttpPost("employee")]
    public async Task<EmployeeResult> AddEmployee(
        [FromBody] CreateEmployeeCommand command
    )
    {
        command.Actor = await GetUser();
        return _mapper.Map<EmployeeResult>(await _mediator.Send(command));
    }

    [HttpDelete("employee/{id}")]
    public async Task<MessageResult> RemoveEmployee(
        [FromRoute] Guid id
    )
    {
        var command = new DeleteEmployeeCommand { Actor = await GetUser(), EmployeeId = id };
        return new MessageResult(await _mediator.Send(command));
    }

    [HttpPost("change/{companyId}")]
    public async Task<ActualUserResult> ChangeEmployee(
        [FromRoute] Guid companyId
    )
    {
        var command = new ChangeCompanyCommand { Actor = await GetUser(), CompanyId = companyId };
        return _mapper.Map<ActualUserResult>(await _mediator.Send(command));
    }
}
