using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();

        builder.HasMany(x => x.Permissions).WithOne(p => p.Role).HasForeignKey(x => x.RoleId);
        builder.HasMany(x => x.Employees).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Company).WithMany(x => x.Roles).HasForeignKey(x => x.CompanyId).IsRequired();
    }
}
