using Workshop.Domain.Entities;
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

    public void Create(Order order)
    {
        _context.Add(order);
        _context.SaveChanges();
    }

    public void Delete(Order order)
    {
        _context.Remove(order);
        _context.SaveChanges();
    }

    public List<Order> GetAll(Guid CompanyId)
    {
        var orders = _context.Orders.Where(x => x.Employee.CompanyId == CompanyId).ToList();

        return orders;
    }

    public Order GetById(Guid id, Guid CompanyId)
    {
        var order = _context.Orders.First(x => x.Employee.CompanyId == CompanyId && x.Id == id);

        return order;
    }

    public int GetMaxOrderNumber(Guid companyId)
    {
        var maxNumber = _context.Orders.Max(x => x.OrderNumber);

        return maxNumber;
    }

    public void Update(Order order)
    {
        _context.Update(order);
        _context.SaveChanges();
    }
}
