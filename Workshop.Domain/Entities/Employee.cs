namespace Workshop.Domain.Entities;

public class Employee : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    public Role Role { get; set; }
    public List<Permission> Permissions { get; set; }

    public Employee(Guid userId, Guid companyId)
    {
        UserId = userId;
        CompanyId = companyId;
    }

    public Employee(Guid userId, Guid companyId, Role role)
    {
        UserId = userId;
        CompanyId = companyId;
        Role = role;
    }

    public bool VerifyPermission(string resourceCode)
    {
        var permissionFinded = Permissions.Find(perm => perm.ResourceCode == resourceCode || perm.ResourceCode == "resource:owner");
        permissionFinded ??= Role.Permissions.Find(perm => perm.ResourceCode == resourceCode || perm.ResourceCode == "resource:owner");

        return permissionFinded != null;
    }
}
