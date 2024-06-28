using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.GetById;

public class GetRoleByIdHandler(IRoleRepository roleRepository) : IRequestHandler<GetRoleByIdQuery, Role>
{
    public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee == null) throw new AuthorizationException("Usuário sem permissão");
        var role = await roleRepository.GetById(request.RoleId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(role, "Cargo não encontrado!");

        return role;
    }
}
