using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.GetRoles;

public class GetRolesQuery : IQuery<ICollection<Role>>
{
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
