using MediatR;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.GetEmployees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, ICollection<Employee>>
{
    public Task<ICollection<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) return Task.FromResult<ICollection<Employee>>([]);

        return Task.FromResult<ICollection<Employee>>(request.Actor.Employee.Company.Employees);
    }
}
