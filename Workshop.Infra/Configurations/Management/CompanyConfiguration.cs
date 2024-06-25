using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();

        builder.HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId).IsRequired();
        builder.HasMany(x => x.Employees).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        builder.HasMany(x => x.Roles).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        builder.HasMany(x => x.Clients).WithOne(x => x.Company).HasForeignKey(c => c.CompanyId);
    }
}
