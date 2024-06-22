using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.GetById;

public class GetOrderByIdQuery : IQuery<Order?>
{
    public Guid OrderId { get; set; }
    public User Actor { get; set; } = null!;
}
