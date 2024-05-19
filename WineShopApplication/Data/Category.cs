namespace WineShopApplication.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Subcategory>? Subcategories { get; set; }
    }

    public class CategoryJson
    {
        public required string name { get; set; }
        public required string description { get; set; }
    }
}
