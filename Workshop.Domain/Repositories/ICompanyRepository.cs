using Workshop.Domain.Entities.Management;

namespace Workshop.Domain.Repositories;

public interface ICompanyRepository
{
    Task<Company?> GetById(Guid id);
    Task Create(Company company);
    Task Update(Company company);
}
