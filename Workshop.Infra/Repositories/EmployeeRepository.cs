using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class EmployeeRepository(WorkshopDBContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
    public async Task<Employee?> GetById(Guid id, Guid companyId)
    {
        return await context.Employees.FirstOrDefaultAsync(e => e.Id == id && e.CompanyId == companyId);
    }
}
