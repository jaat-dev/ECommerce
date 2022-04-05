using Ecommerce.Order.Service.EventHandlerss.Commands;
using Ecommerce.Order.Services.Queries;
using Ecommerce.Order.Services.Queries.DTOs;
using ECommerce.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Order.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IMediator _mediator;

        public OrderController(
            IMediator mediator,
            IOrderQueryService orderQueryService)
        {
            _mediator = mediator;
            _orderQueryService = orderQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<OrderDto>?> GetAll(
            int page = 1,
            int take = 10)
        {
            return await _orderQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<OrderDto?> Get(int id)
        {
            return await _orderQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}
