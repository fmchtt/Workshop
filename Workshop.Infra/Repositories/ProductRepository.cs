using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Domain.ValueObjects.Stock.Products;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class ProductRepository(WorkshopDBContext context) : BaseRepository<Product>(context), IProductRepository
{
    private readonly DbSet<Product> _products = context.Set<Product>();

    public async Task<ICollection<Product>> GetAll(Guid companyId)
    {
        return await _products.Where(p => p.OwnerId == companyId && !p.Deleted).ToListAsync();
    }

    public async Task<ICollection<Product>> GetAll(Guid companyId, FilterGetAllProducts filters)
    {
        var products = _products.Where(p => p.OwnerId == companyId && !p.Deleted);

        if(filters.Name is not null)
        {
            products = products.Where(e => e.Name.Contains(filters.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        return await products.ToListAsync();
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
