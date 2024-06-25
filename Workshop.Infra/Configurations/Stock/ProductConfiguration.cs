using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Domain.Entities.Management;

namespace Workshop.Infra.Configurations.Stock;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Description);
        builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
        builder.Property(x => x.ModifiedDate);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.QuantityInStock).IsRequired();
        builder.Property(x => x.Deleted).HasDefaultValue(false);

        builder.HasOne(x => x.Owner).WithMany().HasForeignKey(x => x.OwnerId).IsRequired();
    }
}
