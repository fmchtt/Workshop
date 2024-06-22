

using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.GetAll;

public class GetAllOrdersQuery : IQuery<ICollection<Order>>
{
    public User Actor { get; set; } = null!;
}
