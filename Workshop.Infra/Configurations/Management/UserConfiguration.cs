using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Name);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();

        builder.HasMany(x => x.Employees).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Employee).WithOne().HasForeignKey<User>(x => x.ActiveEmployeeId).OnDelete(DeleteBehavior.SetNull);
    }
}
