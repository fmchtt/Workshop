using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class ProductInOrderRepository(WorkshopDBContext context) : IProductInOrderRepository
{
    public async Task<ProductInOrder?> GetById(Guid id)
    {
        return await context.ProductInOrders.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Create(ProductInOrder entity)
    {
        context.ProductInOrders.Add(entity);
        await context.SaveChangesAsync();
    }

    public async Task Update(ProductInOrder entity)
    {
        context.ProductInOrders.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(ProductInOrder entity)
    {
        context.ProductInOrders.Remove(entity);
        await context.SaveChangesAsync();
    }
}
