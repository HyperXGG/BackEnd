namespace WineShopApplication.Data
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Product>? Products { get; set; }
    }
}
