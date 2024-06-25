using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.CompleteOrder;

public class CompleteOrderCommand : ICommand<Order>
{
    public Guid OrderId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
