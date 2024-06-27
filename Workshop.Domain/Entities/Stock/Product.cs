using Workshop.Domain.Entities.Shared;

namespace Workshop.Domain.Entities.Management;

public class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public bool Deleted { get; set; }
    public Guid OwnerId { get; set; }
    public virtual Company Owner { get; set; } = null!;

    public Product()
    {
    }

    public Product(string name, string description, decimal price, int quantityInStock, Company owner)
    {
        Name = name;
        Description = description;
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        Price = price;
        Owner = owner;
        OwnerId = owner.Id;
        QuantityInStock = quantityInStock;
    }
}
