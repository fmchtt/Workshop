using Workshop.Domain.Entities.Shared;
using Workshop.Domain.Exceptions;

namespace Workshop.Domain.Entities.Management;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;
    public Guid CompanyId { get; init; }
    public virtual Company Company { get; init; } = null!;
    public virtual List<Permission> Permissions { get; init; } = [];
    public virtual List<Employee> Employees { get; init; } = [];

    public Role()
    {
    }

    public Role(string name, Company company)
    {
        Name = name;
        Company = company;
        CompanyId = company.Id;
    }

    public Role(string name, Company company, List<Permission> permissions)
    {
        Name = name;
        Company = company;
        CompanyId = company.Id;
        Permissions = permissions;
    }

    public bool HasPermission(string type, string value)
    {
        return Permissions.Any(p => p.Type == type && p.Value == value);
    }

    public void AddPermission(string type, string value)
    {
        var permissionValid = Permission.ValidatePermission(type, value);
        if (!permissionValid)
        {
            throw new ValidationException("Permissão inválida!");
        }
        Permissions.Add(new Permission(type, value, this));
    }

    public void RemovePermission(Permission permission)
    {
        Permissions.Remove(permission);
    }
}
