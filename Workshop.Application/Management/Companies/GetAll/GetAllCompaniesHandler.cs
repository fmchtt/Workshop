using MediatR;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.GetAll;

public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, ICollection<Company>>
{
    public Task<ICollection<Company>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = request.Actor.Employees.Select(x => x.Company).ToList();
        return Task.FromResult<ICollection<Company>>(companies);
    }
}
