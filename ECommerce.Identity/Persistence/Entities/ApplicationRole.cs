﻿using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Identity.Persistence.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole>? UserRoles { get; set; }
    }
}