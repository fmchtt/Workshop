using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class CompanyRepository(WorkshopDBContext context) : BaseRepository<Company>(context), ICompanyRepository
{
}
