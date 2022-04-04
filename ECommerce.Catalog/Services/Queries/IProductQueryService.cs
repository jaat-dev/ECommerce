using ECommerce.Catalog.Services.Queries.DTOs;
using ECommerce.Common;

namespace ECommerce.Catalog.Services.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDto>?> GetAllAsync(int page, int take, IEnumerable<int>? products = null);
        Task<ProductDto?> GetAsync(int id);
    }
}
