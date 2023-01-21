using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IProductRepository
{
    Product GetByID(Guid id, Guid companyId);
    List<Product> GetAll(Guid companyId);
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
}
