using MediatR;

namespace Ecommerce.Customer.Service.EventHandlers.Commands
{
    public class ClientCreateCommand : INotification
    {
        public string? Name { get; set; }
    }
}
