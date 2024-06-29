using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Management.Customer;

namespace Workshop.Domain.Repositories;

public interface IClientRepository : IRepository<Client>
{
    Task<Client?> GetById(Guid id, Guid companyId);
    Task<ICollection<Client>> GetAll(Guid companyId);
    Task<ICollection<Client>> GetAll(Guid companyId, FilterGetAllClients filters);
}
