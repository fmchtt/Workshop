using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Configurations.Service;

internal class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
        builder.Property(x => x.ModifiedDate);

        builder.HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId).IsRequired();
    }
}
