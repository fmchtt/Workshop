using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => new { e.UserId, e.CompanyId }).IsUnique();

        builder.HasOne(e => e.User).WithMany(e => e.Employees).HasForeignKey(e => e.UserId).IsRequired();
        builder.HasOne(e => e.Company).WithMany(c => c.Employees).HasForeignKey(c => c.CompanyId).IsRequired();
        builder.HasOne(e => e.Role).WithMany().HasForeignKey(e => e.RoleId).IsRequired();
    }
}
