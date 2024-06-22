using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.CreatePermission;

public class CreatePermissionCommand : ICommand<Role>
{
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
    public Guid RoleId { get; set; } = Guid.Empty;
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
