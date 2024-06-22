using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Service;

namespace Workshop.Infra.Configurations.Service;

internal class ProductInOrderConfiguration : IEntityTypeConfiguration<ProductInOrder>
{
    public void Configure(EntityTypeBuilder<ProductInOrder> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.OrderId, x.ProductId }).IsUnique();

        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).IsRequired();
        builder.HasOne(x => x.Order).WithMany(x => x.Products).HasForeignKey(x => x.OrderId).IsRequired();
    }
}
