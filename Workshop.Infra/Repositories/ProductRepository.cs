using Workshop.Domain.Entities;
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

    public void Create(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Remove(product);
        _context.SaveChanges();
    }

    public List<Product> GetAll(Guid companyId)
    {
        var product = _context.Products.Where(p => p.OwnerId == companyId).ToList();

        return product;
    }

    public Product GetByID(Guid id, Guid companyId)
    {
        var product = _context.Products.First(p => p.Id == id && p.OwnerId == companyId);

        return product;
    }

    public void Update(Product product)
    {
        _context.Update(product);
        _context.SaveChanges();
    }
}
