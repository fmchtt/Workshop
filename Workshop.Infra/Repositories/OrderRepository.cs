using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class OrderRepository(WorkshopDBContext context) : RepositoryBase<WorkshopDBContext, Order>(context),IOrderRepository
{
    private readonly DbSet<Order> _orders = context.Set<Order>();

    public async Task<ICollection<Order>> GetAll(Guid CompanyId)
    {
        return await _orders.Where(x => x.Employee.CompanyId == CompanyId).ToListAsync();
    }

    public async Task<Order?> GetById(Guid id, Guid CompanyId)
    {
        return await _orders.FirstOrDefaultAsync(x => x.Employee.CompanyId == CompanyId && x.Id == id);
    }

    public Task<Order> CreateAndReturn(Order order)
    {
        var newOrder = _orders.Add(order);
        return Task.FromResult(newOrder.Entity);
    }
}
