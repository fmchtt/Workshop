using Workshop.Domain.Contracts;
using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetById(Guid id, Guid companyId);
    Task<ICollection<Product>> GetAll(Guid companyId);
}
