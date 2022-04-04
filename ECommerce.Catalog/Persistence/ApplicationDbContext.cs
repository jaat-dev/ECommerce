using ECommerce.Catalog.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Catalog.Persistence.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) : base(options)
        {
            //Add-Migration -Name InitDataBase -OutputDir Persistence/Migrations
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Catalog");

            // Model Contraints
            ModelConfig(builder);
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductInStock>? Stocks { get; set; }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new ProductConfiguration(modelBuilder.Entity<Product>());
            _ = new ProductInStockConfiguration(modelBuilder.Entity<ProductInStock>());
        }
    }
}
