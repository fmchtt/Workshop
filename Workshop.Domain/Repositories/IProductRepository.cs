using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Stock.Products;

namespace Workshop.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetById(Guid id, Guid companyId);
    Task<ICollection<Product>> GetAll(Guid companyId);
    Task<ICollection<Product>> GetAll(Guid companyId, FilterGetAllProducts filters);
    Task UpdateRange(ICollection<Product> products);
}
