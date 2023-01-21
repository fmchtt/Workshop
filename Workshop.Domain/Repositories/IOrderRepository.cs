using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IOrderRepository
{
    Order GetById(Guid id, Guid CompanyId);
    List<Order> GetAll (Guid CompanyId);
    int GetMaxOrderNumber(Guid companyId);
    void Create(Order order);
    void Update(Order order);
    void Delete(Order order);
}
