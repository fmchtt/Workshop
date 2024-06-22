using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Stock.Products.GetById;

public class GetProductByIdQuery : IQuery<Product?>
{
    public Guid ProductId { get; set; }
    public User Actor { get; set; }
}
