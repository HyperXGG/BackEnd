namespace WineShopApplication.Models.ProductModels
{
    public class ProductInputModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int SubcategoryId { get; set; }
        public int ProducerId { get; set; }
        public List<ProductInventoryInputModel>? Inventories { get; set; }
    }
}
