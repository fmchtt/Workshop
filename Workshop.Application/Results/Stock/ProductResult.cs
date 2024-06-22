namespace Workshop.Application.Results.Stock;

public class ProductResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}
