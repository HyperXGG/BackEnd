namespace WineShopApplication.Models.ProductModels
{
    public class ProductInventoryInputModel
    {
        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public int ShelfNumber { get; set; }
        public int Amount { get; set; }
    }
}
