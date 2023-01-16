using Workshop.Domain.Contracts.Results;
using Workshop.Domain.DTO.CompanyDTO;
using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;
using Workshop.Domain.UseCases.Contracts;

namespace Workshop.Domain.UseCases.CompanyUseCases;

public class CreateCompanyUseCase : IUseCase<CreateCompanyDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyUseCase(IUserRepository userRepository, ICompanyRepository companyRepository)
    {
        _userRepository = userRepository;
        _companyRepository = companyRepository;
    }

    public GenericResult handle(CreateCompanyDTO data)
    {
        data.Validate();
        if (data.Invalid)
        {
            return new InvalidDataResult("company", data.Notifications);
        }

        var owner = _userRepository.GetById(data.OwnerId);
        if (owner == null)
        {
            return new NotFoundResult("user");
        }

        var company = new Company(data.Name, data.OwnerId);
        _companyRepository.Create(company);

        return new SuccessResult("Empresa criada com sucesso!", company);
    }
}
