using Workshop.Domain.Entities.Service;

namespace Workshop.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetById(Guid id, Guid CompanyId);
    Task<ICollection<Order>> GetAll(Guid CompanyId);
    Task<Order> Create(Order order);
    Task Update(Order order);
    Task Delete(Order order);
}
