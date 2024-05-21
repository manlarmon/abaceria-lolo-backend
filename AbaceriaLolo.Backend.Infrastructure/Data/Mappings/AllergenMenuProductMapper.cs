using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings
{
    public class AllergenMenuProductMapper : IEntityTypeConfiguration<AllergenMenuProductModel>
    {
        public void Configure(EntityTypeBuilder<AllergenMenuProductModel> builder)
        {
            builder.ToTable("AllergenProduct");

            builder.HasKey(ap => ap.AllergenMenuProductId);

            builder.Property(ap => ap.AllergenId)
                .HasColumnName("AllergenId");

            builder.Property(ap => ap.MenuProductId)
                .HasColumnName("MenuProductId");

            // This is the relationship between AllergenProductModel and AllergenModel
            builder.HasOne(ap => ap.Allergen)
                .WithMany(a => a.AllergenMenuProduct)
                .HasForeignKey(ap => ap.AllergenId);

            // This is the relationship between AllergenProductModel and MenuProductModel
            builder.HasOne(ap => ap.MenuProduct)
                .WithMany(mp => mp.AllergenMenuProduct)
                .HasForeignKey(ap => ap.MenuProductId);

        }
    }
}
