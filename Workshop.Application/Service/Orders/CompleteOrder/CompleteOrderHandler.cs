using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.CompleteOrder;

public class CompleteOrderHandler(IOrderRepository orderRepository) : IRequestHandler<CompleteOrderCommand, Order>
{
    public async Task<Order> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        if (order.Complete)
        {
            throw new AuthorizationException("Ordem de serviço já concluída!");
        }

        order.Complete = true;
        await orderRepository.Update(order);

        return order;
    }
}
