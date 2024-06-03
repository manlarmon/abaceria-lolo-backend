using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers
{
    public class MenuSectionMapper : IEntityTypeConfiguration<MenuSectionModel>
    {
        public void Configure(EntityTypeBuilder<MenuSectionModel> builder)
        {
            builder.ToTable("MenuSection");

            builder.HasKey(ms => ms.MenuSectionId);
            builder.Property(ms => ms.MenuSectionId).HasColumnName("MenuSectionId");

            builder.Property(ms => ms.Order)
                .IsRequired().HasColumnName("Order")
                .HasDefaultValue(0);

            builder.Property(mp => mp.IsVisible)
                .IsRequired()
                .HasColumnName("isVisible");

            builder.Property(ms => ms.MenuSectionName)
                .IsRequired().HasColumnName("MenuSectionName");

            // This is the relationship between MenuSectionModel and MenuProductModel
            builder.HasMany(ms => ms.MenuProducts)
                .WithOne(mp => mp.MenuSection)
                .HasForeignKey(mp => mp.MenuSectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
