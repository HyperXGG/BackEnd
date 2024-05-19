namespace WineShopApplication.Models.ProductModels
{
    public class ProductInventoryOutputModel
    {
        public int? StorageId { get; set; }
        public string? StorageName { get; set; }
        public int ShelfNumber { get; set; }
        public int Amount { get; set; }
    }
}
