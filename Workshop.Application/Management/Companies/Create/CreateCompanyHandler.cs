using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.Create;

public class CreateCompanyHandler(ICompanyRepository repository, IRoleRepository roleRepository, IUserRepository userRepository, IEmployeeRepository employeeRepository) : IRequestHandler<CreateCompanyCommand, Company>
{
    public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company(request.Name, request.Actor.Id);
        await repository.Create(company);

        var role = new Role("Administrador", company.Id);
        foreach (var type in Permission.List.Keys)
        {
            foreach (var value in Permission.List[type])
            {
                role.AddPermission(type, value);
            }
        }
        await roleRepository.Create(role);

        var employee = new Employee(request.Actor.Id, company.Id, role.Id);
        await employeeRepository.Create(employee);

        request.Actor.ActiveEmployeeId = employee.Id;
        await userRepository.Update(request.Actor);

        return company;
    }
}
