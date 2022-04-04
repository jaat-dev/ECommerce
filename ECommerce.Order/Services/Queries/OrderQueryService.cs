using Ecommerce.Order.Persistence;
using Ecommerce.Order.Services.Queries.DTOs;
using ECommerce.Common;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Order.Services.Queries
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<OrderDto>?> GetAllAsync(int page, int take)
        {
            var collection = await _context!.Orders!
                .Include(x => x.Items)
                .OrderByDescending(x => x.OrderId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<OrderDto>?>();
        }

        public async Task<OrderDto?> GetAsync(int id)
        {
            return (await _context!.Orders!.Include(x => x.Items).SingleAsync(x => x.OrderId == id)).MapTo<OrderDto>();
        }
    }
}
