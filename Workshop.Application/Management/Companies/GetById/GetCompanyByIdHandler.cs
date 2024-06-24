

using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.GetById;

public class GetCompanyByIdHandler(ICompanyRepository companyRepository) : IRequestHandler<GetCompanyByIdQuery, Company?>
{
    public async Task<Company?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await companyRepository.GetById(request.CompanyId);
        NotFoundException.ThrowIfNull(company, "Empresa não encontrada!");

        return company;
    }
}
