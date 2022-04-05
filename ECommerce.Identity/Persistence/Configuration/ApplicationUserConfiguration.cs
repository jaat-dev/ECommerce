using Ecommerce.Identity.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Identity.Persistence.Configuration
{
    public class ApplicationUserConfiguration
    {
        public ApplicationUserConfiguration(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            entityBuilder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);
            entityBuilder.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
    }
}
