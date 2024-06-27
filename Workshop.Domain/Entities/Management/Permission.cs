using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Permission : Entity
{
    public string Type { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;

    public Guid RoleId { get; init; }
    public virtual Role Role { get; set; } = null!;

    public Permission()
    {
    }

    public Permission(string type, string value, Role role)
    {
        Type = type;
        Value = value;
        Role = role;
        RoleId = role.Id;
    }

    public static readonly Dictionary<string, List<string>> List = new()
    {
        { "management", ["manageRole", "manageEmployee", "addPermission", "manageClient", "manageCompany"] },
        { "stock", ["manageProduct"] },
        { "service", ["manageOrder"] }
    };

    public static bool ValidatePermission(string type, string value)
    {
        return List.Any(t => t.Key == type && t.Value.Contains(value));
    }
}
