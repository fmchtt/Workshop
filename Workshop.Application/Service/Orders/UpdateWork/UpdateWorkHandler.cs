using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.UpdateWork;

public class UpdateWorkHandler(IOrderRepository orderRepository, IWorkRepository workRepository) : IRequestHandler<UpdateWorkCommand, Work>
{
    public async Task<Work> Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageOrder") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var order = await orderRepository.GetById(request.OrderId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(order, "Ordem de serviço não encontrada!");

        var work = order.Works.Find(p => p.Id == request.WorkId);
        NotFoundException.ThrowIfNull(work, "Mão de obra não encontrado na ordem de serviço!");

        work.Description = request.Description;
        work.Price = request.Price;
        work.TimeToFinish = request.TimeToFinish;

        await workRepository.Update(work);

        return work;
    }
}
