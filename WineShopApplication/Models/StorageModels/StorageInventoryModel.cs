namespace WineShopApplication.Models.StorageModels
{
    public class StorageInventoryModel
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int ShelfNumber { get; set; }
        public int Amount { get; set; }
    }
}
