using System;
using AbaceriaLolo.Backend.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using AbaceriaLolo.Backend.Infrastructure.Data.Mappings.Mappers;
    

namespace AbaceriaLolo.Backend.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                }
                else
                {
                    throw new InvalidOperationException("MYSQL_CONNECTION_STRING environment variable is not set.");
                }
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
            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new InventorySectionMapper());
            modelBuilder.ApplyConfiguration(new InventoryProductMapper());
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<AllergenModel> Allergen { get; set; }
        public DbSet<MenuProductModel> MenuProduct { get; set; }
        public DbSet<MenuSectionModel> MenuSection { get; set; }
        public DbSet<TypeOfServingModel> TypeOfServing { get; set; }
        public DbSet<AllergenMenuProductModel> AllergenMenuProduct { get; set; }
        public DbSet<MenuProductPriceModel> MenuProductPrice { get; set; }
        public DbSet<InventorySectionModel> InventorySection { get; set; }
        public DbSet<InventoryProductModel> InventoryProduct { get; set; }
    }
}
