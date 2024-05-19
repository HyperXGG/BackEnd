namespace WineShopApplication.Models.ProductModels
{
    public class ProductOutputModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public required string SubcategoryName { get; set; }
        public required string ProducerName { get; set; }
        public List<ProductInventoryOutputModel>? Inventories { get; set; }
    }
}
