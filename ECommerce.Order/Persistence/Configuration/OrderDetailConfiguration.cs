using Ecommerce.Order.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.Database.Configuration
{
    public class OrderDetailConfiguration
    {
        public OrderDetailConfiguration(EntityTypeBuilder<OrderDetail> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OrderDetailId);
            entityBuilder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
            entityBuilder.Property(x => x.Total).HasColumnType("decimal(18,2)");
        }
    }
}
