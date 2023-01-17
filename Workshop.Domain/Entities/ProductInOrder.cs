namespace Workshop.Domain.Entities;

public class ProductInOrder : Entity
{
    public Guid ProductId { get; set;}
    public Product Product { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public int Quantity { get; set; }

    public ProductInOrder(Guid productId, Guid orderId, int quantity)
    {
        ProductId = productId;
        OrderId = orderId;
        Quantity = quantity;
    }
}
