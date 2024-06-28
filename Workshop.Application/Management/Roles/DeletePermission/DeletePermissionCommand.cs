using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.DeletePermission;

public class DeletePermissionCommand : ICommand<string>
{
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
    [JsonIgnore]
    public Guid RoleId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
