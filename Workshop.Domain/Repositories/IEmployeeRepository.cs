using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(Guid id);
    Task Create(Employee employee);
    Task Update(Employee employee);
    Task Delete(Employee employee);
}
