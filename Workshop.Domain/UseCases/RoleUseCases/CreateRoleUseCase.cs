using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.Input.RoleDTO;
using Workshop.Domain.DTO.Output.RoleDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.RoleUseCases;

public class CreateRoleUseCase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPermissionRepository _permissionRepository;

    public CreateRoleUseCase(
        IEmployeeRepository employeeRepository,
        IRoleRepository roleRepository,
        IPermissionRepository permissionRepository
    )
    {
        _roleRepository = roleRepository;
        _employeeRepository = employeeRepository;
        _permissionRepository = permissionRepository;
    }

    public GenericResult Handle(CreateRoleDTO data, Guid executorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("role", data.Notifications);
        }

        var user = _employeeRepository.GetByUserId(executorId);
        if (user == null)
        {
            return new InvalidDataResult("user", data.Notifications);
        }

        if (!user.VerifyPermission("role:create"))
        {
            return new UnauthorizedResult("role:create");
        }

        var permissions = new List<Permission>();
        foreach (var perm in data.PermissionIdList)
        {
            var permission = _permissionRepository.GetById(perm);
            if (permission == null)
            {
                return new InvalidDataResult("permission");
            }

            permissions.Add(permission);
        }

        var role = new Role(data.Name, user.CompanyId, permissions);
        _roleRepository.Create(role);

        return new SuccessResult("Role criado com sucesso!", new RoleResultDTO(role));
    }
}
