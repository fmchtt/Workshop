using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.GetById;

public class GetOrderByIdHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderByIdQuery, Order?>
{
    public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
    }
}
