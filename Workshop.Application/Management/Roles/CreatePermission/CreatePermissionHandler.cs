using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.CreatePermission;

public class CreatePermissionHandler(IRoleRepository roleRepository) : IRequestHandler<CreatePermissionCommand, Role>
{
    public async Task<Role> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "addPermission") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var role = await roleRepository.GetById(request.RoleId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(role, "Cargo não encontrado!");

        role.AddPermission(request.Type, request.Value);
        await roleRepository.Update(role);

        return role;
    }
}
