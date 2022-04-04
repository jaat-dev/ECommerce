using Ecommerce.Order.Services.Queries.DTOs;
using ECommerce.Common;

namespace Ecommerce.Order.Services.Queries
{
    public interface IOrderQueryService
    {
        Task<DataCollection<OrderDto>?> GetAllAsync(int page, int take);
        Task<OrderDto?> GetAsync(int id);
    }
}
