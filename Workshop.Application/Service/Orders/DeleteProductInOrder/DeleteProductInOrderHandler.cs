using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.DeleteProductInOrder;

public class DeleteProductInOrderHandler(IOrderRepository orderRepository) : IRequestHandler<DeleteProductInOrderCommand, string>
{
    public async Task<string> Handle(DeleteProductInOrderCommand request, CancellationToken cancellationToken)
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

        var productInOrder = order.Products.Find(x => x.ProductId == request.ProductId);
        NotFoundException.ThrowIfNull(productInOrder, "Produto não encontrado na ordem de serviço!");

        order.RemoveProduct(productInOrder.Product, request.Quantity);
        await orderRepository.Update(order);

        return "Produto removido da ordem de serviço com sucesso!";
    }
}
