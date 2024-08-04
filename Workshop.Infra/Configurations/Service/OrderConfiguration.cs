using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Configurations.Service;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.OrderNumber).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Complete).HasDefaultValue(false);

        builder.HasOne(x => x.Employee).WithMany().HasForeignKey(x => x.EmployeeId).IsRequired();
        builder.HasOne(x => x.Company).WithMany().HasForeignKey(x => x.CompanyId).IsRequired();
        builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.ClientId).IsRequired();
        builder.HasMany(x => x.Products).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).IsRequired();
        builder.HasMany(x => x.Works).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
    }
}
