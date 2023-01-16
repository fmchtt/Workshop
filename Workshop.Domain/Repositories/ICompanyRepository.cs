using Workshop.Domain.Entities;

namespace Workshop.Domain.Repositories;

public interface ICompanyRepository
{
    Company GetById(Guid id);
    void Create(Company company);
    void Update(Company company);
    void AddEmployee(Employee employee);
}
