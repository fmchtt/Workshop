using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class ProductRepository(WorkshopDBContext context) : RepositoryBase<WorkshopDBContext, Product>(context), IProductRepository
{
    private readonly DbSet<Product> _products = context.Set<Product>();

    public async Task<ICollection<Product>> GetAll(Guid companyId)
    {
        return await _products.Where(p => p.OwnerId == companyId && !p.Deleted).ToListAsync();
    }

    public async Task<Product?> GetById(Guid id, Guid companyId)
    {
        return await _products.FirstOrDefaultAsync(p => p.Id == id && p.OwnerId == companyId && !p.Deleted);
    }

    public Task UpdateRange(ICollection<Product> products)
    {
        _products.UpdateRange(products);
        return Task.CompletedTask;
    }
}
