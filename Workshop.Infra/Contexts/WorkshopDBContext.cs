using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Entities;
namespace Workshop.Infra.Contexts;

public class WorkshopDBContext : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($@"{Environment.GetEnvironmentVariable("CONNECTION_STRING")}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasMany(c => c.ReceivingServices).WithMany();
        modelBuilder.Entity<Role>().HasMany(r => r.Permissions).WithMany();
    }
}
