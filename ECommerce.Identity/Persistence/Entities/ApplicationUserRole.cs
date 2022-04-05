using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Identity.Persistence.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole? Role { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
