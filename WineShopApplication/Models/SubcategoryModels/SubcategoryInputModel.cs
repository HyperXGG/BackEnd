namespace WineShopApplication.Models.SubcategoryModels
{
    public class SubcategoryInputModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}
