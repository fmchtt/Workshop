using MediatR;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.GetEmployees;

public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, ICollection<Employee>>
{
    public Task<ICollection<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) return Task.FromResult<ICollection<Employee>>([]);

        var employees = request.Actor.Employee.Company.Employees;

        if (request.Filters is null) return Task.FromResult<ICollection<Employee>>(employees);

        if(request.Filters.Name is not null)
        {
            employees = employees.Where(e => e.User.Name.Contains(request.Filters.Name, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        if (request.Filters.Email is not null)
        {
            employees = employees.Where(e => e.User.Email.Contains(request.Filters.Email, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        return Task.FromResult<ICollection<Employee>>(employees);
    }
}
