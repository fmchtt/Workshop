using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.GetEmployees;

public class GetAllEmployeesQuery : IQuery<ICollection<Employee>>
{
    public User Actor { get; set; } = User.Empty;
}
