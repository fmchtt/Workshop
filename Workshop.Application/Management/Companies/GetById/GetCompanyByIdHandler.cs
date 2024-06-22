

using MediatR;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.GetById;

public class GetCompanyByIdHandler(ICompanyRepository companyRepository) : IRequestHandler<GetCompanyByIdQuery, Company?>
{
    public async Task<Company?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        return await companyRepository.GetById(request.CompanyId);
    }
}
