using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.GetAll;

public class GetAllProductsHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, ICollection<Product>>
{
    public async Task<ICollection<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee is null) return [];

        if (request.Filter is null) return await productRepository.GetAll(request.Actor.Employee.CompanyId);

        return await productRepository.GetAll(request.Actor.Employee.CompanyId, request.Filter);
    }
}
