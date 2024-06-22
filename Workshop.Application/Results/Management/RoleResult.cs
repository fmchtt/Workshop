namespace Workshop.Application.Results.Management;

public class RoleResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<PermissionResult> Permissions { get; set; } = [];
}
