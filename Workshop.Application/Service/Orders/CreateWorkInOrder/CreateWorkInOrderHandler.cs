using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.CreateWork;

public class CreateWorkInOrderHandler(IOrderRepository orderRepository, IWorkInOrderRepository workInOrderRepository, IWorkRepository workRepository) 
    : IRequestHandler<CreateWorkInOrderCommand, WorkInOrder>
{
    public async Task<WorkInOrder> Handle(CreateWorkInOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        if (order.Complete)
        {
            throw new AuthorizationException("Ordem de serviço concluída não pode ser editada!");
        }

        var workInOrder = await workInOrderRepository.GetWorkByIdAndOrderId(request.WorkId, order.Id);
        
        if(workInOrder is not null)
        {
            throw new ValidationException("Já existe uma mão de obra com esse nome nessa Ordem de serviço");
        }

        var work = await workRepository.GetById(request.WorkId);
        NotFoundException.ThrowIfNull(work, "Mão de obra não encontrada!");

        workInOrder = new WorkInOrder(request.Price, request.DateInit, request.DateFinish, work, order);

        order.Works.Add(workInOrder);
        await workRepository.Create(work);
        await orderRepository.Update(order);

        return workInOrder;
    }
}
