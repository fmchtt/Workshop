namespace Workshop.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int Price { get; set; }

    public Guid OwnerId { get; set; }

    public Company Owner { get; set; }

    public Product(string name, string description, int price, Guid ownerId)
    {
        Name = name;
        Description = description;
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
        Price = price;
        OwnerId = ownerId;
    }
}
