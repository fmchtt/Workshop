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

    public Employee(Guid userId, Guid companyId, Guid roleId)
    {
        UserId = userId;
        CompanyId = companyId;
        RoleId = roleId;
    }

    public bool HasPermission(string type, string value)
    {
        return UserId == Company.OwnerId || Role.HasPermission(type, value);
    }
}
