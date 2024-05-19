namespace WineShopApplication.Models.CategoryModels
{
    public class CategoryOutputModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<string>? Subcategories { get; set; }
    }
}
