using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId)
                .HasColumnName("UserId");

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.IsAdmin)
                .HasColumnName("IsAdmin")
                .HasDefaultValue(false);

            builder.Property(x => x.Enabled)
                .HasColumnName("Enabled")
                .HasDefaultValue(true);
        }
    }
}
