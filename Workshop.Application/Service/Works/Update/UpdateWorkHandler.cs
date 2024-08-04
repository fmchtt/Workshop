using MediatR;
using Workshop.Application.Service.Orders.Update;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Works.Update;

public class UpdateWorkHandler(IWorkRepository workRepository) : IRequestHandler<UpdateWorkCommand, Work>
{
    public async Task<Work> Handle(UpdateWorkCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageWork") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var work = await workRepository.GetByDescription(request.Description!, request.Actor.Employee.CompanyId);

        if (work is not null)
            throw new ValidationException("Já existe essa mão de obra");

        work = await workRepository.GetById(request.WorkId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(work, "Mão de obra não encontrada");
            
        work.Description = request.Description;

        await workRepository.Update(work);

        return work;
    }
}
