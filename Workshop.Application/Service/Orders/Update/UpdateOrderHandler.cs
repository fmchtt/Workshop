using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.Update;

public class UpdateOrderHandler(IOrderRepository orderRepository, IEmployeeRepository employeeRepository, IClientRepository clientRepository) : IRequestHandler<UpdateOrderCommand, Order>
{
    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
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

        if (request.EmployeeId.HasValue)
        {
            var employee = await employeeRepository.GetById(request.EmployeeId.Value, request.Actor.Employee.CompanyId);
            NotFoundException.ThrowIfNull(employee, "Colaborador não encontrado!");
            order.EmployeeId = request.EmployeeId.Value;
            order.Employee = employee;
        }

        if (request.ClientId.HasValue)
        {
            var client = await clientRepository.GetById(request.ClientId.Value, request.Actor.Employee.CompanyId);
            NotFoundException.ThrowIfNull(client, "Cliente não encontrado!");
            order.ClientId = request.ClientId.Value;
            order.Client = client;
        }
        await orderRepository.Update(order);

        return order;
    }
}
