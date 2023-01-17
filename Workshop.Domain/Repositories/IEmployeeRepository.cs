using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IEmployeeRepository
{
    void Create(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
}
