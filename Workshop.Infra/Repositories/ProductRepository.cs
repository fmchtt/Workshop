using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WorkshopDBContext _context;

    public ProductRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Product>> GetAll(Guid companyId)
    {
        return await _context.Products.Where(p => p.OwnerId == companyId).ToListAsync();
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product?> GetById(Guid id, Guid companyId)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id && p.OwnerId == companyId);
    }

    public async Task Create(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }
}
