using Ecommerce.Catalog.Models;
using ECommerce.Catalog.Persistence.Entities;
using ECommerce.Catalog.Services.EventHandlers.Commands;
using ECommerce.Catalog.Services.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Catalog.Services.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler :
        INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(
            ApplicationDbContext context,
            ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public string? Message { get; set; }

        public async Task Handle(
            ProductInStockUpdateStockCommand notification, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started ---");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context!.Stocks!.Where(x => products.Contains(x.ProductId)).ToListAsync(cancellationToken: cancellationToken);
            _logger.LogInformation("--- Retrieve products from database ---");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);
                if (entry is null)
                {
                    _logger.LogError("Product {{0}} - doens't have enough stock ---", entry!.ProductId);
                    throw new ProductInStockUpdateStockCommandException($"Product {entry!.ProductId} - doens't have enough stock");
                }

                if (item.Action == ProductInStockAction.Substract)
                {
                    if (item.Stock > entry.Stock)
                    {
                        _logger.LogError("Product {{0}} - doens't have enough stock ---", entry!.ProductId);
                        throw new ProductInStockUpdateStockCommandException($"Product {entry!.ProductId} - doens't have enough stock");
                    }

                    entry.Stock -= item.Stock;

                    _logger.LogInformation("--- Product {ProductId} - its stock was subtracted and its new stock is {Stock} ---",  
                        entry.ProductId, entry.Stock);
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        _logger.LogInformation("--- New stock record was created for {ProductId} because didn't exists before", entry.ProductId);
                        await _context.AddAsync(entry, cancellationToken);
                    }

                    _logger.LogInformation($"--- Add stock to product ---");
                    entry.Stock += item.Stock;
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended ---");
        }
    }
}
