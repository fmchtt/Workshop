using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.GetById;

public class GetProductByIdHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, Product?>
{
    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) throw new AuthorizationException("Usuário sem permissão");

        var product = await productRepository.GetById(request.ProductId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(product, "Produto não encontrado!");

        return product;
    }
}
