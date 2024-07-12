using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Service;

public class Work : Entity
{
    public decimal Price { get; set; }
    public TimeOnly TimeToFinish { get; set; }
    public string? Description { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }

    public Work()
    {
    }

    public Work(decimal price, TimeOnly timeToFinish, string? description, Order order)
    {
        Price = price;
        TimeToFinish = timeToFinish;
        Description = description;
        OrderId = order.Id;
        Order = order;
    }
}
