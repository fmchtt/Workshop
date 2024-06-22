using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IClientRepository : IRepository<Client>
{
    Task<Client?> GetById(Guid id, Guid companyId);
    Task<ICollection<Client>> GetAll(Guid companyId);
}
