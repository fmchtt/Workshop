using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.GetAll;

public class GetAllProductsHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, ICollection<Product>>
{
    public async Task<ICollection<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) return [];

        return await productRepository.GetAll(request.Actor.Employee.CompanyId);
    }
}
