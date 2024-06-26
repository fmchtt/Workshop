using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class ProductInOrderRepository(WorkshopDBContext context) : BaseRepository<ProductInOrder>(context), IProductInOrderRepository
{
    private readonly DbSet<ProductInOrder> _productInOrders = context.Set<ProductInOrder>();

    public async Task CreateOrUpdate(ProductInOrder productInOrder)
    {
        var exists = await _productInOrders.ContainsAsync(productInOrder);
        if (exists)
        {
            _productInOrders.Update(productInOrder);
        }
        else
        {
            _productInOrders.Add(productInOrder);
        }
    }
}
