using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;


namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings
{
    public class MenuProductMapper : IEntityTypeConfiguration<MenuProductModel>
    {
        public void Configure(EntityTypeBuilder<MenuProductModel> builder)
        {
            builder.ToTable("MenuProduct");

            builder.HasKey(mp => mp.MenuProductId);

            builder.Property(mp => mp.MenuProductName)
                .IsRequired()
                .HasColumnName("MenuProductName");

            builder.Property(mp => mp.Order)
                .IsRequired()
                .HasColumnName("Order");

            builder.Property(mp => mp.MenuSectionId)
                .IsRequired()
                .HasColumnName("MenuSectionId");

            // This is the relationship between MenuProductModel and AllergenProductModel
            builder.HasMany(mp => mp.AllergenMenuProduct)
                .WithOne(ap => ap.MenuProduct)
                .HasForeignKey(ap => ap.MenuProductId);

            // This is the relationship between MenuProductModel and MenuSectionModel
            builder.HasOne(mp => mp.MenuSection).
                WithMany(ms => ms.MenuProducts)
                .HasForeignKey(mp => mp.MenuSectionId);

            // This is the relationship between MenuProductModel and MenuProductPriceModel
            builder.HasMany(mp => mp.MenuProductPrice)
                .WithOne(mpp => mpp.MenuProduct)
                .HasForeignKey(mpp => mpp.MenuProductId);
        }
    }
}
