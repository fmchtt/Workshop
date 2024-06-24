using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public bool Deleted { get; set; }
    public Guid OwnerId { get; set; }
    public virtual Company Owner { get; set; } = null!;

    public Product(string name, string description, decimal price, int quantityInStock, Guid ownerId)
    {
        Name = name;
        Description = description;
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        Price = price;
        OwnerId = ownerId;
        QuantityInStock = quantityInStock;
    }
}
