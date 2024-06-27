using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;
using Workshop.Infra.Shared;

namespace Workshop.Infra.Repositories;

public class EmployeeRepository(WorkshopDBContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
}
