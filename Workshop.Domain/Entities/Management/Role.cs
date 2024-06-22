using Workshop.Domain.Entities.Shared;
using Workshop.Domain.Exceptions;

namespace Workshop.Domain.Entities.Management;

public class Role : Entity
{
    public string Name { get; init; }
    public Guid CompanyId { get; init; }
    public virtual Company Company { get; init; } = null!;
    public virtual List<Permission> Permissions { get; init; } = [];

    public Role(string name, Guid companyId)
    {
        Name = name;
        CompanyId = companyId;
    }

    public Role(string name, Guid companyId, List<Permission> permissions)
    {
        Name = name;
        CompanyId = companyId;
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
        Permissions.Add(new Permission(type, value, Id));
    }
}
