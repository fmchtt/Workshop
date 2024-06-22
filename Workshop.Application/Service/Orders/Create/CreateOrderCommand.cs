using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.Create;

public class CreateOrderCommand : ICommand<Order>
{
    public Guid ClientId { get; set; }
    public Guid EmployeeId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
