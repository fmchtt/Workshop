using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.GetById;

public class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product?>
{
    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await productRepository.GetById(request.ProductId, request.Actor.Employee.CompanyId);
    }
}
