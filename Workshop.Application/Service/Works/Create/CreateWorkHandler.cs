using MediatR;
using Workshop.Domain.Entities.Service;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Service.Works.Create;

public class CreateWorkHandler(IWorkRepository workRepository) : IRequestHandler<CreateWorkCommand, Work>
{
    public async Task<Work> Handle(CreateWorkCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("service", "manageWork") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var work = await workRepository.GetByDescription(request.Description!, request.Actor.Employee.CompanyId);

        if (work is not null)
            throw new ValidationException("Já existe essa mão de obra");

        work = new Work(request.Description, request.Actor.Employee.Company);

        return await workRepository.CreateAndReturn(work);
    }
}
