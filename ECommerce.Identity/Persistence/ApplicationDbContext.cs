using Ecommerce.Identity.Persistence.Configuration;
using Ecommerce.Identity.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Identity.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Identity");

            // Model Contraints
            ModelConfig(builder);
        }

        private static void ModelConfig(ModelBuilder modelBuilder)
        {
            _ = new ApplicationUserConfiguration(modelBuilder.Entity<ApplicationUser>());
            _ = new ApplicationRoleConfiguration(modelBuilder.Entity<ApplicationRole>());
        }
    }
}
