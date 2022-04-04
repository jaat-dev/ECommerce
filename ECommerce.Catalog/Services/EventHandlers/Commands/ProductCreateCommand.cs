using MediatR;

namespace ECommerce.Catalog.Services.EventHandlers.Commands
{
    public class ProductCreateCommand : INotification
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
