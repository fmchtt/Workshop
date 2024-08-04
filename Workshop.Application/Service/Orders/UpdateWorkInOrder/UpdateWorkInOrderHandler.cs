using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.UpdateWork;

public class UpdateWorkHandler(IOrderRepository orderRepository, IWorkInOrderRepository workInOrderRepository) : IRequestHandler<UpdateWorkInOrderCommand, WorkInOrder>
{
    public async Task<WorkInOrder> Handle(UpdateWorkInOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        var workInOrder = order.Works.Find(p => p.Id == request.WorkId);
        NotFoundException.ThrowIfNull(workInOrder, "Mão de obra não encontrado na ordem de serviço!");

        workInOrder.DateInit = request.DateInit;
        workInOrder.Price = request.Price;
        workInOrder.DateFinish = request.DateFinish;

        await workInOrderRepository.Update(workInOrder);

        return workInOrder;
    }
}
