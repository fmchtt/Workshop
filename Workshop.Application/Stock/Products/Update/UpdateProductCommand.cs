using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.Update;

public class UpdateProductCommand : ICommand<Product>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
