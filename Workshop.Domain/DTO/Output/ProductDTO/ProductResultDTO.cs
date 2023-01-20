using Workshop.Domain.Entities;

namespace Workshop.Domain.DTO.Output.ProductDTO;

public class ProductResultDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }

    public ProductResultDTO(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Stock = product.Stock;
    }
}
