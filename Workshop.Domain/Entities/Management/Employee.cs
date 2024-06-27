using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Employee : Entity
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; } = null!;
    public Employee()
    {
    }

    public Employee(User user, Company company, Role role)
    {
        User = user;
        UserId = user.Id;
        Company = company;
        CompanyId = company.Id;
        Role = role;
        RoleId = role.Id;
    }

    public bool HasPermission(string type, string value)
    {
        return UserId == Company.OwnerId || Role.HasPermission(type, value);
    }
}
