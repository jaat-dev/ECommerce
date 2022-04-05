﻿using Ecommerce.Identity.Persistence.Entities;
using Ecommerce.Identity.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Identity.Service.EventHandlers
{
    public class UserCreateEventHandler :
        IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserCreateEventHandler(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(
            UserCreateCommand notification,
            CancellationToken cancellationToken)
        {
            var entry = new ApplicationUser
            {
                FirstName = notification.FirstName,
                LastName = notification.LastName,
                Email = notification.Email,
                UserName = notification.Email
            };

            return await _userManager.CreateAsync(entry, notification.Password);
        }
    }
}
