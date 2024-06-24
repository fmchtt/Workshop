using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.Update;

public class UpdateOrderCommand : ICommand<Order>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
    public Guid? ClientId { get; set; }
    public Guid? EmployeeId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
