using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.Update;

public class UpdateRoleHandler(IRoleRepository roleRepository) : IRequestHandler<UpdateRoleCommand, Role>
{
    public async Task<Role> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {

        if (request.Actor.Employee?.HasPermission("management", "manageRole") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var role = await roleRepository.GetById(request.RoleId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(role, "Cargo não encontrado!");

        if (request.Name != null)
        {
            role.Name = request.Name;
        }

        await roleRepository.Update(role);

        return role;
    }
}
