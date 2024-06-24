using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.Delete;

public class DeleteRoleCommand : ICommand<string>
{
    public Guid RoleId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
