using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly WorkshopDBContext _context;

    public OrderRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Order>> GetAll(Guid CompanyId)
    {
        return await _context.Orders.Where(x => x.Employee.CompanyId == CompanyId).ToListAsync();
    }

    public async Task<Order?> GetById(Guid id, Guid CompanyId)
    {
        return await _context.Orders.FirstOrDefaultAsync(x => x.Employee.CompanyId == CompanyId && x.Id == id);
    }

    public async Task<Order> Create(Order order)
    {
        var newOrder = _context.Add(order);
        await _context.SaveChangesAsync();
        return newOrder.Entity;
    }

    public async Task Update(Order order)
    {
        _context.Update(order);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Order order)
    {
        _context.Remove(order);
        await _context.SaveChangesAsync();
    }
}
