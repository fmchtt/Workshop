using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly WorkshopDBContext _context;

    public CompanyRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public async Task<Company?> GetById(Guid id)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task Create(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Company company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }
}
