using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Roles.GetRoles;

public class GetRolesQuery : IQuery<ICollection<Role>>
{
    public Guid CompanyId { get; set; }
}
