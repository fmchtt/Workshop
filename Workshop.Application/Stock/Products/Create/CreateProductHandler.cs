using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.Create;

public class CreateProductHandler(IProductRepository productRepository) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("stock", "manageProduct") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var product = new Product(request.Name, request.Description, request.Price, request.Quantity, request.Actor.Employee.CompanyId);
        await productRepository.Create(product);

        return product;
    }
}
