using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Ecommerce.Identity.Persistence.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ApplicationUserRole>? UserRoles { get; set; }
    }
}
