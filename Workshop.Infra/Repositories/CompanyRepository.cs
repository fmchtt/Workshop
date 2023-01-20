using Workshop.Domain.Entities;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly WorkshopDBContext _context;

    public CompanyRepository(WorkshopDBContext context) { 
        _context = context;
    }
    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Create(Company company)
    {
        _context.Companies.Add(company);
        _context.SaveChanges();
    }

    public Company GetById(Guid id)
    {
        var company = _context.Companies.First(c => c.Id == id);
        return company;
    }

    public void Update(Company company)
    {
        _context.Companies.Update(company);
        _context.SaveChanges();
    }
}
