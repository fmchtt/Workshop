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

    public WorkshopDBContext(DbContextOptions<WorkshopDBContext> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasMany(c => c.ReceivingServices).WithMany();
        modelBuilder.Entity<Role>().HasMany(r => r.Permissions).WithMany();
        modelBuilder.Entity<Employee>().HasMany(e => e.Permissions).WithMany();
        modelBuilder.Entity<Employee>().HasOne(e => e.User).WithMany();

        modelBuilder.Entity<Permission>().HasData(
            new Permission("ALL", "resource:owner"),

            new Permission("Criar e Gerenciar Empregado", "employee:create"),
            new Permission("Remover Empregado", "employee:delete"),

            new Permission("Criar e Gerenciar Pedidos", "order:create"),
            new Permission("Remover Pedidos", "order:delete"),

            new Permission("Criar e Gerenciar Produto", "product:create"),
            new Permission("Deletar Produto", "product:delete"),

            new Permission("Criar e Gerenciar Cargos", "role:create"),
            new Permission("Deletar Cargos", "role:delete")
        );
    }
}
