using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers
{
    public class InventoryProductMapper : IEntityTypeConfiguration<InventoryProductModel>
    {
        public void Configure(EntityTypeBuilder<InventoryProductModel> builder)
        {
            builder.ToTable("InventoryProduct");

            builder.HasKey(x => x.InventoryProductId);
            builder.Property(x => x.InventoryProductId)
                .HasColumnName("InventoryProductId");

            builder.Property(x => x.InventorySectionId)
                .HasColumnName("InventorySectionId")
                .IsRequired();

            builder.Property(x => x.ProductName)
                .HasColumnName("ProductName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            // Relationship between InventoryProduct and InventorySection
            builder.HasOne(ip => ip.InventorySection)
                .WithMany(x => x.InventoryProducts)
                .HasForeignKey(ip => ip.InventorySectionId);
        }
    }
}
