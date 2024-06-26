﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;

namespace AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers
{
    public class MenuProductPriceMapper : IEntityTypeConfiguration<MenuProductPriceModel>
    {
        public void Configure(EntityTypeBuilder<MenuProductPriceModel> builder)
        {
            builder.ToTable("MenuProductPrice");

            builder.HasKey(mpp => mpp.MenuProductPriceId);

            builder.Property(mpp => mpp.Price)
                .HasColumnName("Price");

            builder.Property(mpp => mpp.MenuProductId)
                .HasColumnName("MenuProductId");

            builder.Property(mpp => mpp.TypeOfServingId)
                .HasColumnName("TypeOfServingId");

            // This is the relationship between MenuProductPriceModel and MenuProductModel
            builder.HasOne(mpp => mpp.MenuProduct)
                .WithMany(mp => mp.MenuProductPrice)
                .HasForeignKey(mpp => mpp.MenuProductId);

            // This is the relationship between MenuProductPriceModel and TypeOfServingModel
            builder.HasOne(mpp => mpp.TypeOfServing)
                .WithMany(ts => ts.MenuProductPrices)
                .HasForeignKey(mpp => mpp.TypeOfServingId);
        }
    }
}
