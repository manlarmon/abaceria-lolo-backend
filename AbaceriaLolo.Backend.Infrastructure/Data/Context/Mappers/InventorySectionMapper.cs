using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers
{
    public class InventorySectionMapper : IEntityTypeConfiguration<InventorySectionModel>
    {
        public void Configure(EntityTypeBuilder<InventorySectionModel> builder)
        {
            builder.ToTable("InventorySection");

            builder.HasKey(x => x.InventorySectionId);
            builder.Property(x => x.InventorySectionId)
                .HasColumnName("InventorySectionId");

            builder.Property(x => x.SectionName)
                .HasColumnName("SectionName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .HasDefaultValue(true);

            // Relationship between InventorySection and InventoryProduct
            builder.HasMany(x => x.InventoryProducts)
                .WithOne(ip => ip.InventorySection)
                .HasForeignKey(ip => ip.InventorySectionId);
        }
    }
}
