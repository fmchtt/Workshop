using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Service.Orders.DeleteProductInOrder;

public class DeleteProductInOrderCommand : ICommand<string>
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
