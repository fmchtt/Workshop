using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.Update;

public class UpdateProductHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand, Product>
{
    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("stock", "manageProduct") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }
        var product = await productRepository.GetById(request.ProductId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(product, "Produto não encontrado!");

        if (request.Name != null)
        {
            product.Name = request.Name;
        }

        if (request.Description != null)
        {
            product.Description = request.Description;
        }

        if (request.Price.HasValue)
        {
            product.Price = request.Price.Value;
        }

        if (request.QuantityInStock.HasValue)
        {
            product.QuantityInStock = request.QuantityInStock.Value;
        }

        await productRepository.Update(product);

        return product;
    }
}
