using Ecommerce.Customer.Service.EventHandlers.Commands;
using ECommerce.Common;
using ECommerce.Customer.Services.Queries;
using ECommerce.Customer.Services.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Customer.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientQueryService _clientQuerService;
        private readonly IMediator _mediator;

        public ClientController(
            IMediator mediator,
            IClientQueryService clientQuerService)
        {
            _mediator = mediator;
            _clientQuerService = clientQuerService;
        }

        [HttpGet]
        public async Task<DataCollection<ClientDto>?> GetAll(
            int page = 1,
            int take = 10,
            string? ids = null)
        {
            // Obtener inforacion de un Claims
            var id = User.Claims
                .SingleOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))
                .Value;
            IEnumerable<int>? clients = null;

            if (!string.IsNullOrEmpty(ids))
            {
                clients = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _clientQuerService.GetAllAsync(page, take, clients);
        }

        [HttpGet("{id}")]
        public async Task<ClientDto?> Get(int id)
        {
            return await _clientQuerService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}
