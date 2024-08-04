using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Domain.Repositories;

public interface IWorkRepository : IRepository<Work>
{
    Task<Work?> GetByDescription(string description, Guid ownerId);
    Task<Work?> GetById(Guid id, Guid CompanyId);
    Task<Work> CreateAndReturn(Work work);
}
