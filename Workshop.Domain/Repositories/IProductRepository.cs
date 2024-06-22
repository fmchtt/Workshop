using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IProductRepository
{
    Task<Product?> GetById(Guid id, Guid companyId);
    Task<ICollection<Product>> GetAll(Guid companyId);
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Product product);
}
