using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    Task CreateOrUpdateRange(ICollection<Permission> permissions);
}
