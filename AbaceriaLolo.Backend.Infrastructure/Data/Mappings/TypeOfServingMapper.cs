using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;


namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings
{
    public class TypeOfServingMapper : IEntityTypeConfiguration<TypeOfServingModel>
    {
        public void Configure(EntityTypeBuilder<TypeOfServingModel> builder)
        {
            builder.ToTable("TypeOfServing");

            builder.HasKey(x => x.TypeOfServingId);
            builder.Property(x => x.TypeOfServingId)
                .HasColumnName("TypeOfServingId");

            builder.Property(x => x.TypeOfServingName)
                .HasColumnName("TypeOfServingName")
                .IsRequired();

            builder.HasMany(ts => ts.MenuProductPrice)
                .WithOne(mpp => mpp.TypeOfServing)
                .HasForeignKey(mpp => mpp.TypeOfServingId);
        }
    }
}
