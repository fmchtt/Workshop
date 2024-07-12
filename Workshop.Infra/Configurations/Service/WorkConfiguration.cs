using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Configurations.Service;

internal class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Description).IsRequired();

        builder.HasOne(x => x.Order).WithMany(x => x.Works).HasForeignKey(x => x.OrderId).IsRequired();
    }
}
