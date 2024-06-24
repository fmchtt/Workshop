using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.DeletePermission;

public class DeletePermissionHandler(IRoleRepository roleRepository, IPermissionRepository permissionRepository) : IRequestHandler<DeletePermissionCommand, string>
{
    public async Task<string> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "addPermission") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var role = await roleRepository.GetById(request.RoleId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(role, "Cargo não encontrado!");
        var permission = role.Permissions.Find(x => x.Id == request.PermissionId);
        NotFoundException.ThrowIfNull(permission, "Permissão não encontrada!");
        role.RemovePermission(permission);

        await permissionRepository.Delete(permission);

        return "Permissão removida com sucesso!";
    }
}
