using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Management;

internal class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email).IsRequired();

        builder.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId);
        builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.CompanyId);
    }
}
