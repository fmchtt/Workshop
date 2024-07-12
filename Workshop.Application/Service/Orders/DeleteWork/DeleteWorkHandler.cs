using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Orders.DeleteWork;

public class DeleteWorkHandler(IOrderRepository orderRepository, IWorkRepository workRepository) : IRequestHandler<DeleteWorkCommand, string>
{
    public async Task<string> Handle(DeleteWorkCommand request, CancellationToken cancellationToken)
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

        var work = order.Works.Find(x => x.Id == request.WorkId);
        NotFoundException.ThrowIfNull(work, "Mão de obra não encontrado na ordem de serviço!");

        order.Works.Remove(work);
        await workRepository.Delete(work);

        return "Mão de obra removido da ordem de serviço com sucesso!";
    }
}
