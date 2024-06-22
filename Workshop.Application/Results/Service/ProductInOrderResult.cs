using Workshop.Application.Results.Stock;

namespace Workshop.Application.Results.Service;

public class ProductInOrderResult
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public ProductResult Product { get; set; } = null!;
}
