using ECommerce.Catalog.Persistence.Entities;
using ECommerce.Catalog.Services.EventHandlers.Commands;
using MediatR;

namespace ECommerce.Catalog.Services.EventHandlers
{
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ProductCreateEventHandler(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(
            ProductCreateCommand notification,
            CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = notification.Name,
                Description = notification.Description,
                Price = notification.Price
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
