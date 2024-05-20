using System;
using System.Collections.Generic;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using AbaceriaLolo.Backend.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;


namespace AbaceriaLolo.Backend.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING")));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new AllergenMapper());
            modelBuilder.ApplyConfiguration(new MenuProductMapper());
            modelBuilder.ApplyConfiguration(new MenuSectionMapper());
            modelBuilder.ApplyConfiguration(new TypeOfServingMapper());
            modelBuilder.ApplyConfiguration(new AllergenMenuProductMapper());
            modelBuilder.ApplyConfiguration(new MenuProductPriceMapper());

        }

        public DbSet<AllergenModel> Allergen { get; set; }
        public DbSet<MenuProductModel> MenuProduct { get; set; }
        public DbSet<MenuSectionModel> MenuSection { get; set; }
        public DbSet<TypeOfServingModel> TypeOfServing { get; set; }
        public DbSet<AllergenMenuProductModel> AllergenProduct { get; set; }
        public DbSet<MenuProductPriceModel> MenuProductPrice { get; set; }


    }
}
