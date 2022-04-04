using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Order.Persistence.Configuration
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Ecommerce.Order.Persistence.Entities.Order> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OrderId);
            entityBuilder.Property(x => x.Total).HasColumnType("decimal(18,2)");
        }
    }
}
