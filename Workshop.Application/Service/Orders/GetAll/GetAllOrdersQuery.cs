

using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.ValueObjects.Service.Orders;

namespace Workshop.Application.Service.Orders.GetAll;

public class GetAllOrdersQuery : IQuery<ICollection<Order>>
{
    public User Actor { get; set; } = null!;
    public FilterGetAllOrders? Filters { get; set; }
}
