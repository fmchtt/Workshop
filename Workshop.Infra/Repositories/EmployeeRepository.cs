using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities;
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

    public void Create(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Delete(Employee employee)
    {
        _context.Remove(employee);
        _context.SaveChanges();
    }

    public Employee GetByUserId(Guid id)
    {
        var employee = _context.Employees
            .Include(x => x.Company)
            .First(x => x.UserId == id);

        return employee;
    }

    public void Update(Employee employee)
    {
        _context.Update(employee);
        _context.SaveChanges();
    }
}
