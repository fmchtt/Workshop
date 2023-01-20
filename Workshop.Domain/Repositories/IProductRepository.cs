using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IProductRepository
{
    Product GetByID(Guid id);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
}
