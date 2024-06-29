using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.GetAll;

public class GetAllOrdersHandler(IOrderRepository orderRepository) : IRequestHandler<GetAllOrdersQuery, ICollection<Order>>
{
    public async Task<ICollection<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) return [];

        if(request.Filters is null) return await orderRepository.GetAll(request.Actor.Employee.CompanyId);

        return await orderRepository.GetAll(request.Actor.Employee.CompanyId, request.Filters);
    }
}
