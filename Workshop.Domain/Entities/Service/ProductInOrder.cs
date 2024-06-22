using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Service;

public class ProductInOrder : Entity
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;

    public ProductInOrder(Guid productId, Guid orderId, int quantity)
    {
        ProductId = productId;
        OrderId = orderId;
        Quantity = quantity;
    }
}
