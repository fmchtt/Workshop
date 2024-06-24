using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    Task CreateRange(ICollection<Permission> permissions);
}
