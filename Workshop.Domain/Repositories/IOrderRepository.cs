using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Service;

namespace Workshop.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order?> GetById(Guid id, Guid companyId);
    Task<ICollection<Order>> GetAll(Guid CompanyId);
    Task<Order> CreateAndReturn(Order order);
}
