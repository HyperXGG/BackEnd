namespace WineShopApplication.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }
        public List<Inventory>? Inventories { get; set; }
    }
}
