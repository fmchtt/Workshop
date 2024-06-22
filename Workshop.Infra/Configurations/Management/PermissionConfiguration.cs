using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.RoleId, x.Type, x.Value });

        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Value).IsRequired();

        builder.HasOne(x => x.Role).WithMany(x => x.Permissions).HasForeignKey(x => x.RoleId);
    }
}
