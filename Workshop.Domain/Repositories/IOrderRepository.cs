using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.ValueObjects.Management.Customer;
using Workshop.Domain.ValueObjects.Service.Orders;

namespace Workshop.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order?> GetById(Guid id, Guid companyId);
    Task<ICollection<Order>> GetAll(Guid CompanyId);
    Task<ICollection<Order>> GetAll(Guid CompanyId, FilterGetAllOrders filters);
    Task<Order> CreateAndReturn(Order order);
    Task<ICollection<Order>> GetAllByClientId(Guid clientId);
    Task<ICollection<Order>> GetAllByClientId(Guid clientId, FilterGetAllByClientId filters);
}
