using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Domain.ValueObjects.Management.Customer;
using Workshop.Domain.ValueObjects.Service.Orders;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class OrderRepository(WorkshopDBContext context) : BaseRepository<Order>(context), IOrderRepository
{
    private readonly DbSet<Order> _orders = context.Set<Order>();

    public async Task<ICollection<Order>> GetAll(Guid CompanyId)
    {
        return await _orders.Where(x => x.Employee.CompanyId == CompanyId).ToListAsync();
    }
    public async Task<ICollection<Order>> GetAll(Guid CompanyId, FilterGetAllOrders filters)
    {
        var order = _orders.Where(x => x.Employee.CompanyId == CompanyId);

        if (filters.Complete is not null)
        {
            order = order.Where(x => x.Complete == filters.Complete);
        }
        if (filters.EmployeeId is not null)
        {
            order = order.Where(x => x.EmployeeId == filters.EmployeeId);
        }
        if (filters.OrderNumber is not null)
        {
            order = order.Where(x => x.OrderNumber == filters.OrderNumber);
        }
        if (filters.ClientId is not null)
        {
            var clientIds = filters.ClientId.Split(',');
            if(clientIds.Length > 0)
            {
                foreach (var clientId in clientIds)
                {
                    order = order.Where(x => x.ClientId == Guid.Parse(clientId));
                }
            }
        }

        return await order.ToListAsync();
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

    public async Task<ICollection<Order>> GetAllByClientId(Guid clientId, FilterGetAllByClientId filters)
    {
        var order = _orders.Where(x => x.ClientId == clientId);

        if (filters.Complete is not null)
        {
            order = order.Where(x => x.Complete == filters.Complete);
        }
        if (filters.OrderNumber is not null)
        {
            order = order.Where(x => x.OrderNumber == filters.OrderNumber);
        }

        return await order.ToListAsync();
    }

    public async Task<ICollection<Order>> GetAllByClientId(Guid clientId)
    {
        return await _orders.Where(x => x.ClientId == clientId).ToListAsync();
    }
}
