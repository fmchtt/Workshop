using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;

namespace Workshop.Application.Service.Orders.UpdateProductInOrder;

public class UpdateProductInOrderCommand : ICommand<ProductInOrder>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
    [JsonIgnore]
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
