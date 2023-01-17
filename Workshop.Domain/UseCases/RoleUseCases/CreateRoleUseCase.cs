using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.RoleDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.RoleUseCases;

public class CreateRoleUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPermissionRepository _permissionRepository;

    public CreateRoleUseCase(
        IUserRepository userRepository,
        IRoleRepository roleRepository, 
        IPermissionRepository permissionRepository
    ) {
        _roleRepository = roleRepository;
        _permissionRepository = permissionRepository;
        _userRepository = userRepository;
    }

    public GenericResult Handle(CreateRoleDTO data, Guid executorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("role", data.Notifications);
        }

        var user = _userRepository.GetById(executorId);
        if (user == null)
        {
            return new InvalidDataResult("user", data.Notifications);
        }

        if (!user.Employee.VerifyPermission("role:create"))
        {
            return new UnauthorizedResult("role:create");
        }

        var permissions = new List<Permission>();
        foreach (var perm in data.PermissionIdList)
        {
            var permission = _permissionRepository.GetById(perm);
            if (permission == null)
            {
                return new InvalidDataResult("permission", null);
            }

            permissions.Add(permission);
        }

        var role = new Role(data.Name, user.Employee.CompanyId, permissions);
        _roleRepository.Create(role);

        return new SuccessResult("Role criado com sucesso!", role);
    }
}
