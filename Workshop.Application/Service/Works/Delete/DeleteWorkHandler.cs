using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Works.Delete;

public class DeleteWorkHandler(IWorkRepository workRepository) : IRequestHandler<DeleteWorkCommand, string>
{
    public async Task<string> Handle(DeleteWorkCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageWork") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var work = await workRepository.GetById(request.WorkId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(work, "Mão de obra não encontrada!");

        await workRepository.Delete(work);

        return "Mão de obra deletada com sucesso!";
    }
}
