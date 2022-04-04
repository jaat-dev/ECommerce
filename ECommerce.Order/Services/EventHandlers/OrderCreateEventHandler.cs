using Ecommerce.Order.Persistence;
using Ecommerce.Order.Persistence.Entities;
using Ecommerce.Order.Service.EventHandlerss.Commands;
using Ecommerce.Order.Services.Proxies.Catalog;
using Ecommerce.Order.Services.Proxies.Catalog.Commands;
using ECommerce.Order.Models;
using MediatR;

namespace Ecommerce.Order.Service.EventHandlers
{
    public class OrderCreateEventHandler :
        INotificationHandler<OrderCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICatalogProxy _catalogProxy;
        private readonly ILogger<OrderCreateEventHandler> _logger;

        public OrderCreateEventHandler(
            ApplicationDbContext context,
            ICatalogProxy catalogProxy,
            ILogger<OrderCreateEventHandler> logger)
        {
            _context = context;
            _catalogProxy = catalogProxy;
            _logger = logger;
        }

        public async Task Handle(
            OrderCreateCommand notification,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- New order creation started");
            var entry = new Ecommerce.Order.Persistence.Entities.Order();

            using (var trx = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                // 01. Prepare detail
                _logger.LogInformation("--- Preparing detail");
                PrepareDetail(entry, notification);

                // 02. Prepare header
                _logger.LogInformation("--- Preparing header");
                PrepareHeader(entry, notification);

                // 03. Create order
                _logger.LogInformation("--- Creating order");
                _ = await _context.AddAsync(entry, cancellationToken);
                _ = await _context.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("--- Order {OrderId} was created", entry.OrderId);

                // 04. Update Stocks
                _logger.LogInformation("--- Updating stock");
                await _catalogProxy.UpdateStockAsync(new ProductInStockUpdateStockCommand
                {
                    Items = notification.Items.Select(x => new ProductInStockUpdateItem
                    {
                        ProductId = x.ProductId,
                        Stock = x.Quantity,
                        Action = ProductInStockAction.Substract
                    })
                });

                await trx.CommitAsync(cancellationToken);
            }

            _logger.LogInformation("--- New order creation ended");
        }

        private static void PrepareDetail(
            Persistence.Entities.Order entry,
            OrderCreateCommand notification)
        {
            entry.Items = notification.Items.Select(x => new OrderDetail
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                UnitPrice = x.Price,
                Total = x.Price * x.Quantity
            }).ToList();
        }

        private static void PrepareHeader(
            Persistence.Entities.Order entry,
            OrderCreateCommand notification)
        {
            // Header information
            entry.Status = OrderStatus.Pending;
            entry.PaymentType = notification.PaymentType;
            entry.ClientId = notification.ClientId;
            entry.CreatedAt = DateTime.UtcNow;

            // Sum
            entry.Total = entry.Items.Sum(x => x.Total);
        }
    }
}
