using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Permission : Entity
{
    public string Type { get; init; }
    public string Value { get; init; }

    public Guid RoleId { get; init; }
    public virtual Role Role { get; set; } = null!;

    public Permission(string type, string value, Guid roleId)
    {
        Type = type;
        Value = value;
        RoleId = roleId;
    }

    public static readonly Dictionary<string, List<string>> List = new()
    {
        { "management", ["addRole", "addEmployee", "addPermission", "manageClient"] },
        { "stock", ["manageProduct"] },
        { "service", ["manageOrder"] }
    };

    public static bool ValidatePermission(string type, string value)
    {
        return List.Any(t => t.Key == type && t.Value.Contains(value));
    }
}
