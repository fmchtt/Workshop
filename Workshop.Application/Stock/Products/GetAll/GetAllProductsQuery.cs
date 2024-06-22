using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.GetAll;

public class GetAllProductsQuery : IQuery<ICollection<Product>>
{
    public User Actor { get; set; } = null!;
}
