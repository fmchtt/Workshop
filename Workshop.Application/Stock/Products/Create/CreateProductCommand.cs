using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.Create;

public class CreateProductCommand : ICommand<Product>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Quantity { get; set; }

    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;

}
