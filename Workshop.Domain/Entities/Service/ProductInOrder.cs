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

    public ProductInOrder()
    {
    }

    public ProductInOrder(Product product, Order order, int quantity)
    {
        ProductId = product.Id;
        Product = product;
        OrderId = order.Id;
        Order = order;
        Quantity = quantity;
    }
}
