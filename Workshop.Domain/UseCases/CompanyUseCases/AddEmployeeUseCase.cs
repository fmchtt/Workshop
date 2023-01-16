using Workshop.Domain.DTO.CompanyDTO;
using Workshop.Domain.DTO.Results;
using Workshop.Domain.Repositories;
using Workshop.Domain.Entities;
using Workshop.Domain.UseCases.Contracts;

namespace Workshop.Domain.UseCases.CompanyUseCases;

public class AddEmployeeUseCase : IUseCase<AddEmployeeDTO>
{
    IUserRepository _userRepository;
    ICompanyRepository _companyRepository;
    IRoleRepository _roleRepository;

    public AddEmployeeUseCase(IUserRepository userRepository, ICompanyRepository companyRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
        _roleRepository = roleRepository;
    }

    public GenericResultDTO handle(AddEmployeeDTO data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResultDTO("employee", data.Notifications);
        }

        var company = _companyRepository.GetById(data.CompanyId);
        if (company == null)
        {
            return new NotFoundResultDTO("company");
        }

        var user = _userRepository.GetByEmail(data.Email);
        if (user == null)
        {
            user = new User(data.Name, data.Email, new Guid().ToString());
            _userRepository.Create(user);
        }

        if (company.Employees.Find(x => x.UserId == user.Id) != null)
        {
            return new InvalidDataResultDTO("user", new());
        }

        var role = _roleRepository.getById(data.RoleId);
        if (role == null)
        {
            return new NotFoundResultDTO("role");
        }
        
        if (role.CompanyId != company.Id)
        {
            return new InvalidDataResultDTO("role", new());
        }

        var newEmployee = new Employee(user.Id, company.Id, role);
        company.Employees.Add(newEmployee);

        return new SuccessResultDTO("Funcionario adicionado com sucesso!", newEmployee);
    }
}
