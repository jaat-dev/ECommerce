using ECommerce.Customer.Persistence.Configuration;
using ECommerce.Customer.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customer.Persistence
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
            builder.HasDefaultSchema("Customer");

            // Model Contraints
            ModelConfig(builder);
        }

        public DbSet<Client>? Clients { get; set; }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new ClientConfiguration(modelBuilder.Entity<Client>());
        }
    }
}
