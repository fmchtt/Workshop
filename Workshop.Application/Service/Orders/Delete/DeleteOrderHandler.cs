using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.Delete;

public class DeleteOrderHandler(IOrderRepository orderRepository, IProductRepository productRepository) : IRequestHandler<DeleteOrderCommand, string>
{
    public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        if (order.Complete)
        {
            throw new AuthorizationException("Ordem de serviço concluída não pode ser editada!");
        }

        var products = new List<Product>();
        foreach (var product in order.Products)
        {
            product.Product.QuantityInStock += product.Quantity;
            products.Add(product.Product);
        }

        await productRepository.UpdateRange(products);
        await orderRepository.Delete(order);

        return "Ordem de serviço deletada com sucesso!";
    }
}
