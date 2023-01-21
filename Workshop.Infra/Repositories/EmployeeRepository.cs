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
        /*
        var user = _context.Users.First(u => u.Id == id);
        if (user == null)
        {
            return null;
        }

        var employee = _context.Employees.First(e => e.Id == user.ActiveEmployeeId);
        */


        var employee = _context.Employees
            .Include(x => x.Company)
            .Join(
                _context.Users, e => e.Id, 
                u => u.ActiveEmployeeId, 
                (e, u) => new { user = u, emp = e }
            )
            .Where(e => e.user.Id == id)
            .Select(e => e.emp)
            .First();

        return employee;
    }

    public void Update(Employee employee)
    {
        _context.Update(employee);
        _context.SaveChanges();
    }
}
