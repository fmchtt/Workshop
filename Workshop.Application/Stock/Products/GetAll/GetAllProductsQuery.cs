using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.ValueObjects.Stock.Products;

namespace Workshop.Application.Stock.Products.GetAll;

public class GetAllProductsQuery : IQuery<ICollection<Product>>
{
    public User Actor { get; set; } = null!;
    public FilterGetAllProducts? Filter { get; set; }
}
