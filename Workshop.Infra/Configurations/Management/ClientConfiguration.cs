using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();

        builder.HasMany(x => x.Orders).WithOne(x => x.Client).HasForeignKey(x => x.ClientId);
        builder.HasOne(x => x.Representative).WithMany().HasForeignKey(x => x.RepresentativeId);
        builder.HasOne(x => x.Company).WithMany(x => x.Clients).HasForeignKey(x => x.CompanyId);
    }
}
