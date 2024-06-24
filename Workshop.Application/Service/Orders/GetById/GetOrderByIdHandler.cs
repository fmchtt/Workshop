using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.GetById;

public class GetOrderByIdHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderByIdQuery, Order?>
{
    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) throw new AuthorizationException("Usuário sem permissão");

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        return order;
    }
}
