using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.RoleDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.RoleUseCases;

public class DeleteRoleUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleUseCase(
        IUserRepository userRepository,
        IRoleRepository roleRepository
    )
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
    }

    public GenericResult Handle(DeleteRoleDTO data, Guid executorId)
    {
        var user = _userRepository.GetById(executorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (!user.Employee.VerifyPermission("role:delete"))
        {
            return new UnauthorizedResult("role:delete");
        }

        var role = _roleRepository.getById(data.RoleId);
        if (user == null)
        {
            return new NotFoundResult("role");
        }

        if (role.CompanyId != user.Employee.CompanyId)
        {
            return new NotFoundResult("role");
        }

        _roleRepository.Delete(data.RoleId);

        return new SuccessResult("Role deletado com sucesso!");
    }
}
