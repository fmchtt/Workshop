using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.Update;

public class UpdateCompanyHandler(ICompanyRepository companyRepository) : IRequestHandler<UpdateCompanyCommand, Company>
{
    public async Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        if (request.Actor.Employee?.HasPermission("management", "manageCompany") != true)
        {
            throw new AuthorizationException("Usuário sem permissão");
        }

        var company = await companyRepository.GetById(request.CompanyId);
        NotFoundException.ThrowIfNull(company, "Empresa não encontrada!");

        if (!company.IsEmployee(request.Actor))
        {
            throw new AuthorizationException("Usuário sem permissão");
        }

        if (request.Name != null)
        {
            company.Name = request.Name;
        }
        await companyRepository.Update(company);

        return company;
    }
}
