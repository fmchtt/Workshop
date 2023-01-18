using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.RoleDTO;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.RoleUseCases;

public class AddPermissionUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPermissionRepository _permissionRepository;

    public AddPermissionUseCase(IUserRepository userRepository, IRoleRepository roleRepository, IPermissionRepository permissionRepository) { 
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _permissionRepository = permissionRepository;
    }

    public GenericResult Handle(AddPermissionDTO data, Guid executorId)
    {
        var user = _userRepository.GetById(executorId);
        if (user == null)
        {
            return new NotFoundResult("user");
        }

        if (user.Employee.VerifyPermission("role:create"))
        {
            return new UnauthorizedResult("role:create");
        }

        var role = _roleRepository.getById(data.RoleId);
        if (role == null)
        {
            return new NotFoundResult("role");
        }

        if (role.CompanyId != user.Employee.CompanyId)
        {
            return new InvalidDataResult("role");
        }

        var permission = _permissionRepository.GetById(data.PermissionId);
        if (permission == null)
        {
            return new NotFoundResult("permission");
        }

        role.Permissions.Add(permission);
        _roleRepository.Update(role);

        return new SuccessResult("Permissão adicionada com sucesso!");
    }
}
