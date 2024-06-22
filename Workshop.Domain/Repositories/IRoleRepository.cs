using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetById(Guid id, Guid companyId);
    Task<ICollection<Role>> GetAll(Guid companyId);
}
