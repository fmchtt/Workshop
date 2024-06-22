using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.Create;

public class CreateRoleCommand : ICommand<Role>
{
    public string Name { get; set; } = string.Empty;
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
