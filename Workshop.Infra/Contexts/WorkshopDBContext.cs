using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities.Management;
using Workshop.Domain.Entities.Service;
using Workshop.Infra.Extensions;
namespace Workshop.Infra.Contexts;

public class WorkshopDBContext(DbContextOptions<WorkshopDBContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductInOrder> ProductInOrders { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        modelBuilder.ApplyConfigurationsFromAssembly(AppDomain.CurrentDomain.Load("Workshop.Infra"));
        modelBuilder.ApplyUtcDateTimeConverter();

        base.OnModelCreating(modelBuilder);
    }
}
