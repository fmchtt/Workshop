using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Roles.Delete;

public class DeleteRoleHandler(IRoleRepository roleRepository) : IRequestHandler<DeleteRoleCommand, string>
{
    public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageRole") != true)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        var role = await roleRepository.GetById(request.RoleId, request.Actor.Employee.CompanyId);
        NotFoundException.ThrowIfNull(role, "Cargo não encontrado!");

        if (role.Employees.Count > 0)
        {
            throw new ValidationException("Não pode haver nenhum colaborador com o cargo associado para apagar!");
        }

        await roleRepository.Delete(role);

        return "Cargo deletado com sucesso!";
    }
}
