namespace ECommerce.Catalog.Persistence.Entities
{
    public class ProductInStock
    {
        public int ProductInStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
