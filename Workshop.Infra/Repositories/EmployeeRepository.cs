using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Repositories;
using Workshop.Infra.Contexts;

namespace Workshop.Infra.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly WorkshopDBContext _context;

    public EmployeeRepository(WorkshopDBContext context)
    {
        _context = context;
    }

    public Task<Employee?> GetById(Guid id)
    {
        return _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Create(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Employee employee)
    {
        _context.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Employee employee)
    {
        _context.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
