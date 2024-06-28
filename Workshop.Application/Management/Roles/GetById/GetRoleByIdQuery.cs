using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.GetById;

public class GetRoleByIdQuery : IQuery<Role>
{
    public Guid RoleId { get; set; }
    public User Actor { get; set; } = User.Empty;
}
