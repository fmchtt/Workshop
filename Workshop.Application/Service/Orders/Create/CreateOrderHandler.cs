using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.Create;

public class CreateOrderHandler(IOrderRepository orderRepository, IEmployeeRepository employeeRepository, IClientRepository clientRepository) : IRequestHandler<CreateOrderCommand, Order>
{
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var employee = await employeeRepository.GetById(request.EmployeeId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(employee, "Colaborador não encontrado!");

        var client = await clientRepository.GetById(request.ClientId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");

        var order = new Order(request.Actor.Employee.Company, employee, client);
        order = await orderRepository.CreateAndReturn(order);

        return order;
    }
}
