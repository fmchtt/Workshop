using MediatR;
using Workshop.Domain.Exceptions;
using Workshop.Domain.Repositories;

namespace Workshop.Application.Management.Companies.Delete;

public class DeleteCompanyHandler(ICompanyRepository companyRepository) : IRequestHandler<DeleteCompanyCommand, string>
{
    public async Task<string> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await companyRepository.GetById(request.CompanyId);
        NotFoundException.ThrowIfNull(company, "Empresa não encontrada!");

        if (company.OwnerId == request.CompanyId)
        {
            throw new AuthorizationException("Usuário sem permissão!");
        }

        await companyRepository.Delete(company);

        return "Empresa deletada com sucesso!";
    }
}
