﻿using MediatR;
using Workshop.Application.Management.Companies.AddEmployee;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.CreateEmployee;

public class CreateEmployeeHandler(IUserRepository userRepository, IEmployeeRepository employeeRepository) : IRequestHandler<CreateEmployeeCommand, Employee>
{
    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "addEmployee") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var user = await userRepository.GetByEmail(request.Email) ?? new User(request.Name, request.Email, Guid.NewGuid().ToString());
        var employee = new Employee(user.Id, request.Actor.Employee.CompanyId, request.RoleId);
        await employeeRepository.Create(employee);

        return employee;
    }
}
