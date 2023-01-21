using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IRoleRepository
{
    Role GetById(Guid roleId, Guid companyId);
    List<Role> GetAll(Guid companyId);
    void Create(Role role);
    void Update(Role role);
    void Delete(Role role);
}
