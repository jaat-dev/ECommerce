using ECommerce.Catalog.Services.EventHandlers.Commands;
using ECommerce.Catalog.Services.Queries;
using ECommerce.Catalog.Services.Queries.DTOs;
using ECommerce.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductQueryService _productQueryService;
        //private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(
            //ILogger<ProductController> logger,
            IMediator mediator,
            IProductQueryService productQueryService)
        {
            //_logger = logger;
            _mediator = mediator;
            _productQueryService = productQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>?> GetAll(int page = 1, int take = 10, string? ids = null)
        {
            IEnumerable<int>? products = null;

            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productQueryService!.GetAllAsync(page, take, products);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto?> Get(int id)
        {
            return await _productQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}
