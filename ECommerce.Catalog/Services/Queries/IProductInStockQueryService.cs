using ECommerce.Catalog.Services.Queries.DTOs;
using ECommerce.Common;

namespace ECommerce.Catalog.Services.Queries
{
    public interface IProductInStockQueryService
    {
        Task<DataCollection<ProductInStockDto>?> GetAllAsync(
            int page, 
            int take, 
            IEnumerable<int>? products = null);
    }
}
