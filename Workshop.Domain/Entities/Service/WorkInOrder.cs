using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Service;

public class WorkInOrder : Entity
{
    public decimal Price { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateFinish { get; set; }
    public Guid WorkId { get; set; }
    public virtual Work Work { get; set; } = null!;
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;

    public WorkInOrder()
    {
    }

    public WorkInOrder(decimal price, DateTime dateInit, DateTime dateFinish, Work work, Order order)
    {
        Price = price;
        DateInit = dateInit;
        DateFinish = dateFinish;
        WorkId = work.Id;
        Work = work;
        OrderId = order.Id;
        Order = order;
    }
}
