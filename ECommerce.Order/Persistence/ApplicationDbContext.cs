using Ecommerce.Order.Persistence.Configuration;
using Ecommerce.Order.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database.Configuration;

namespace Ecommerce.Order.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Order");

            // Model Contraints
            ModelConfig(builder);
        }

        public DbSet<Ecommerce.Order.Persistence.Entities.Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetail { get; set; }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new OrderConfiguration(modelBuilder.Entity<Ecommerce.Order.Persistence.Entities.Order>());
            _ = new OrderDetailConfiguration(modelBuilder.Entity<OrderDetail>());
        }
    }
}
