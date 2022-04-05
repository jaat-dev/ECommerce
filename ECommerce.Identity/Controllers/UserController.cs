using Ecommerce.Identity.Service.Queries;
using Ecommerce.Identity.Service.Queries.DTOs;
using ECommerce.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Identity.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userQueryService;

        public UserController(
            IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<UserDto>> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<string>? users = ids?.Split(',');
            return await _userQueryService.GetAllAsync(page, take, users);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(string id)
        {
            return await _userQueryService.GetAsync(id);
        }
    }
}
