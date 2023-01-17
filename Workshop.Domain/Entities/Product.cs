namespace Workshop.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid OwnerId { get; set; }
    public Company Owner { get; set; }

    public Product(string name, string description, Decimal price, Guid ownerId, int stock)
    {
        Name = name;
        Description = description;
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        Price = price;
        OwnerId = ownerId;
        Stock = stock;
    }
}
