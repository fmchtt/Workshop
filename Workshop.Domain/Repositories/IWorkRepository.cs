using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Domain.Repositories;

public interface IWorkRepository : IRepository<Work>
{
    Task<Work?> GetWorkByOrderAndDescription(Guid orderId, string description);
}
