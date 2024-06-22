using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.Create;

public class CreateOrderHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, Order>
{
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var order = new Order(request.Actor.Employee.CompanyId, request.EmployeeId, request.ClientId);
        order = await orderRepository.Create(order);

        return order;
    }
}
