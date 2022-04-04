using ECommerce.Catalog.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Catalog.Persistence.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ProductId);

            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            entityBuilder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            var random = new Random();
            var products = new List<Product>();

            for (var i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"Product {i}",
                    Description = $"Description for product {i}",
                    Price = random.Next(100, 1000)
                });
            }

            entityBuilder.HasData(products);
        }
    }
}
