using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.Create;

internal class CreateRoleHandler(IRoleRepository repository) : IRequestHandler<CreateRoleCommand, Role>
{
    public async Task<Role> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageRole") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var role = new Role(request.Name, request.Actor.Employee.Company);
        await repository.Create(role);

        return role;
    }
}
