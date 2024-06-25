using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Service;

namespace Workshop.Domain.Repositories;

public interface IProductInOrderRepository : IRepository<ProductInOrder>
{
    Task CreateOrUpdate(ProductInOrder productInOrder);
}
