namespace WineShopApplication.Models.SubcategoryModels
{
    public class SubcategoryOutputModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string CategoryName { get; set; }
        public List<SubcategoryProductModel>? Products { get; set; }
    }
}
