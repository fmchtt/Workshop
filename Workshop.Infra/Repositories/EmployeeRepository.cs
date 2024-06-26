using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class EmployeeRepository(WorkshopDBContext context) : RepositoryBase<WorkshopDBContext, Employee>(context),IEmployeeRepository
{
}
