using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Stock.Products.Delete;

public class DeleteProductHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductCommand, string>
{
    public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("stock", "manageProduct") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }
        var product = await productRepository.GetById(request.ProductId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(product, "Produto não encontrado!");

        await productRepository.Delete(product);

        return "Produto deletado com sucesso!";
    }
}
