using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.CreateProductInOrder;

public class CreateProductInOrderCommand : ICommand<ProductInOrder>
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
