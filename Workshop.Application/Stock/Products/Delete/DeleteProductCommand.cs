using System.Text.Json.Serialization;
using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.Delete;

public class DeleteProductCommand : ICommand<string>
{
    public Guid ProductId { get; set; }
    [JsonIgnore]
    public User Actor { get; set; } = User.Empty;
}
