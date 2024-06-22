using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IRoleRepository
{
    Task<Role?> GetById(Guid roleId, Guid companyId);
    Task<ICollection<Role>> GetAll(Guid companyId);
    Task Create(Role role);
    Task Update(Role role);
    Task Delete(Role role);
}
