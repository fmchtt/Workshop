using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.Update;

public class UpdateRoleCommand : ICommand<Role>
{
    public string? Name { get; set; }
    [JsonIgnore]
    public Guid RoleId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
