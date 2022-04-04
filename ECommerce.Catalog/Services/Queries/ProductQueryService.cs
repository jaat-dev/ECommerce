using ECommerce.Catalog.Persistence.Entities;
using ECommerce.Catalog.Services.Queries.DTOs;
using ECommerce.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Catalog.Services.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DataCollection<ProductDto>?> GetAllAsync(
            int page, 
            int take, 
            IEnumerable<int>? products = null)
        {
            var collection = await _context!.Products!
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto?> GetAsync(int id)
        {
            return (await _context!.Products!.SingleAsync(x => x.ProductId == id))
                .MapTo<ProductDto?>();
        }
    }
}
