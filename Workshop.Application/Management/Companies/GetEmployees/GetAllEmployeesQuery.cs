using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Management.Companies;

namespace Workshop.Application.Management.Companies.GetEmployees;

public class GetAllEmployeesQuery : IQuery<ICollection<Employee>>
{
    public User Actor { get; set; } = User.Empty;
    public GetAllEmployeesFilter? Filters { get; set; }
}
