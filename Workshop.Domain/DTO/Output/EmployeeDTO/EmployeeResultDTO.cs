using Workshop.Domain.Entities;

namespace Workshop.Domain.DTO.Output.EmployeeDTO;

public class EmployeeResultDTO
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Company Company { get; set; }
    public Role Role { get; set; }
    public List<Permission> Permissions { get; set; }

    public EmployeeResultDTO(Employee employee)
    {
        Id = employee.Id;
        User = employee.User;
        Role = employee.Role;
        Permissions = employee.Permissions;
        Role = employee.Role;
        Company = employee.Company;
    }
}
