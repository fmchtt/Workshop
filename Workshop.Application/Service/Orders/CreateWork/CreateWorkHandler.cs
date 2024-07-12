using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.CreateWork;

public class CreateWorkHandler(IOrderRepository orderRepository, IWorkRepository workRepository) : IRequestHandler<CreateWorkCommand, Work>
{
    public async Task<Work> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
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

        var work = await workRepository.GetWorkByOrderAndDescription(order.Id, request.Description!);
        
        if(work is not null)
        {
            throw new ValidationException("Já existe uma mão de obra com esse nome nessa Ordem de serviço");
        }

        work = new Work(request.Price, request.TimeToFinish, request.Description, order);

        order.Works.Add(work);
        await workRepository.Create(work);
        await orderRepository.Update(order);

        return work;
    }
}
