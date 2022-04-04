using ECommerce.Common;
using ECommerce.Customer.Services.Queries.DTOs;

namespace ECommerce.Customer.Services.Queries
{
    public interface IClientQueryService
    {
        Task<DataCollection<ClientDto>?> GetAllAsync(int page, int take, IEnumerable<int>? clients = null);
        Task<ClientDto?> GetAsync(int id);
    }
}
