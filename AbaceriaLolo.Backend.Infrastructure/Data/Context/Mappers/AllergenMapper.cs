using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers
{
    public class AllergenMapper : IEntityTypeConfiguration<AllergenModel>
    {
        public void Configure(EntityTypeBuilder<AllergenModel> builder)
        {
            builder.ToTable("Allergen");
            builder.HasKey(a => a.AllergenId);
            builder.Property(a => a.AllergenId)
                .HasColumnName("AllergenId");

            builder.Property(a => a.Abbreviation)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("Abbreviation");

            builder.Property(a => a.AllergenName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("AllergenName");

            builder.HasMany(a => a.AllergenMenuProduct)
                .WithOne(ap => ap.Allergen)
                .HasForeignKey(ap => ap.AllergenId);

        }
    }
}
