using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.Delete;

public class DeleteOrderCommand : ICommand<string>
{
    public Guid OrderId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
