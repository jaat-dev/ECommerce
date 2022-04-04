using Ecommerce.Order.Services.Proxies.Catalog.Commands;

namespace Ecommerce.Order.Services.Proxies.Catalog
{
    public interface ICatalogProxy
    {
        Task UpdateStockAsync(ProductInStockUpdateStockCommand command);
    }
}
