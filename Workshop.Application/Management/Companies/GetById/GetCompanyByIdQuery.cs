using Workshop.Application.Shared;
using Workshop.Domain.Entities.Management;

namespace Workshop.Application.Management.Companies.GetById;

public class GetCompanyByIdQuery : IQuery<Company?>
{
    public Guid CompanyId { get; set; } = Guid.Empty;
}
