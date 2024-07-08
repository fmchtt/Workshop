using AutoMapper;
using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.Update;

public class UpdateCompanyHandler(ICompanyRepository companyRepository, IAddressRepository addressRepository, IMapper mapper) 
    : IRequestHandler<UpdateCompanyCommand, Company>
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

        if(request.Address is not null)
        {
            company.Address = mapper.Map<Address>(request.Address);
            await addressRepository.Create(company.Address);
            company.AddressId = company.Address.Id;
        }

        if(request.Cnpj is not null)
        {
            company.Cnpj = request.Cnpj;
        }

        if(request.Logo is not null)
        {
            company.Logo = request.Logo;
        }

        await companyRepository.Update(company);

        return company;
    }
}
