using MediatR;
using Workshop.Application.Management.Companies.AddEmployee;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.CreateEmployee;

public class CreateEmployeeHandler(IUserRepository userRepository, IEmployeeRepository employeeRepository, IRoleRepository roleRepository) : IRequestHandler<CreateEmployeeCommand, Employee>
{
    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageEmployee") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var role = await roleRepository.GetById(request.RoleId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(role, "Cargo não encontrado!");

        var user = await userRepository.GetByEmail(request.Email);
        if (user == null)
        {
            user = new User(request.Name, request.Email, Guid.NewGuid().ToString());
            await userRepository.Create(user);
        }

        var employee = new Employee(user, request.Actor.Employee.Company, role);
        await employeeRepository.Create(employee);

        return employee;
    }
}
