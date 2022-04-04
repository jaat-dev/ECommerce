using ECommerce.Catalog.Persistence.Entities;
using ECommerce.Catalog.Services.Queries.DTOs;
using ECommerce.Common;

namespace ECommerce.Catalog.Services.Queries
{
    public class ProductInStockQueryService : IProductInStockQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductInStockQueryService(ApplicationDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<DataCollection<ProductInStockDto>?> GetAllAsync(
            int page, 
            int take, 
            IEnumerable<int>? products = null)
        {
            var collection = await _context!.Stocks!
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderBy(x => x.ProductId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductInStockDto>>();
        }
    }
}
