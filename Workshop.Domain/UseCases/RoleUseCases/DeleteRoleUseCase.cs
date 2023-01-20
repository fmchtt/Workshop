using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.Input.RoleDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.RoleUseCases;

public class DeleteRoleUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleUseCase(
        IEmployeeRepository employeeRepository,
        IRoleRepository roleRepository
    )
    {
        _roleRepository = roleRepository;
        _employeeRepository = employeeRepository;
    }

    public GenericResult Handle(DeleteRoleDTO data, Guid executorId)
    {
        var user = _employeeRepository.GetByUserId(executorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.VerifyPermission("role:delete"))
        {
            return new UnauthorizedResult("role:delete");
        }

        var role = _roleRepository.getById(data.RoleId);
        if (user == null)
        {
            return new NotFoundResult("role");
        }

        if (role.CompanyId != user.CompanyId)
        {
            return new NotFoundResult("role");
        }

        _roleRepository.Delete(role);

        return new SuccessResult("Role deletado com sucesso!");
    }
}
