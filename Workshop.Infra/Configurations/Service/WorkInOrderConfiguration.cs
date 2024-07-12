using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Configurations.Service;

internal class WorkInOrderConfiguration : IEntityTypeConfiguration<WorkInOrder>
{
    public void Configure(EntityTypeBuilder<WorkInOrder> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.DateInit);
        builder.Property(x => x.DateFinish);

        builder.HasOne(x => x.Order).WithMany(x => x.Works).HasForeignKey(x => x.OrderId).IsRequired();
        builder.HasOne(x => x.Work).WithMany().HasForeignKey(x => x.WorkId).IsRequired();
    }
}
