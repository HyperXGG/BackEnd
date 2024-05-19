namespace WineShopApplication.Models.ProducerModels
{
    public class ProducerProductModel
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public required string SubcategoryName { get; set; }
        public double Price { get; set; }
    }
}
