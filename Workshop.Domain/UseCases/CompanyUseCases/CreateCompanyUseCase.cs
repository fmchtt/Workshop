using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.CompanyDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;

namespace Workshop.Domain.UseCases.CompanyUseCases;

public class CreateCompanyUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPermissionRepository _permissionRepository;

    public CreateCompanyUseCase(
        IUserRepository userRepository,
        ICompanyRepository companyRepository,
        IRoleRepository roleRepository,
        IEmployeeRepository employeeRepository,
        IPermissionRepository permissionRepository
    )
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _roleRepository = roleRepository;
        _employeeRepository = employeeRepository;
        _permissionRepository = permissionRepository;
    }

    public GenericResult Handle(CreateCompanyDTO data, Guid ExecutorId)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("company", data.Notifications);
        }

        var owner = _userRepository.GetById(ExecutorId);
        if (owner == null)
        {
            return new NotFoundResult("user");
        }

        var company = new Company(data.Name, ExecutorId);
        _companyRepository.Create(company);

        var permission = _permissionRepository.GetByResourceName("resource:owner");

        var permList = new List<Permission>
        {
            permission
        };

        var role = new Role("Owner", company.Id, permList);
        _roleRepository.Create(role);

        var employee = new Employee(ExecutorId, company.Id, role);
        _employeeRepository.Create(employee);

        return new SuccessResult("Empresa criada com sucesso!", company);
    }
}
