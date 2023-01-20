using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface IEmployeeRepository
{
    Employee GetByUserId(Guid id);
    void Create(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
}
