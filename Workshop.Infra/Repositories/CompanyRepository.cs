using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class CompanyRepository(WorkshopDBContext context) : RepositoryBase<WorkshopDBContext, Company>(context), ICompanyRepository
{
}
