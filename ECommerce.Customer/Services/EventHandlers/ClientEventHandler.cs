using Ecommerce.Customer.Persistence;
using Ecommerce.Customer.Service.EventHandlers.Commands;
using ECommerce.Customer.Persistence.Entities;
using MediatR;

namespace Ecommerce.Customer.Service.EventHandlers
{
    public class ClientEventHandler : INotificationHandler<ClientCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ClientEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            _ = await _context.AddAsync(new Client
            {
                Name = notification.Name
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
