using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Domain.Repositories;

public interface IWorkInOrderRepository : IRepository<WorkInOrder>
{
    Task<WorkInOrder?> GetWorkByIdAndOrderId(Guid workId, Guid orderId);
}
