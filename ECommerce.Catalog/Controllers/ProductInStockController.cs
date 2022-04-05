using ECommerce.Catalog.Services.EventHandlers.Commands;
using ECommerce.Catalog.Services.Queries;
using ECommerce.Catalog.Services.Queries.DTOs;
using ECommerce.Common;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/stocks")]
    public class ProductInStockController : ControllerBase
    {
        private readonly IProductInStockQueryService _productInStockQueryService;
        private readonly IMediator _mediator;

        public ProductInStockController(
            IMediator mediator,
            IProductInStockQueryService productInStockQueryService)
        {
            _mediator = mediator;
            _productInStockQueryService = productInStockQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<ProductInStockDto>?> GetAll(
            int page = 1, 
            int take = 10, 
            string? products = null)
        {
            IEnumerable<int>? ids = null;

            if (!string.IsNullOrEmpty(products))
            {
                ids = products.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productInStockQueryService.GetAllAsync(page, take, ids);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
