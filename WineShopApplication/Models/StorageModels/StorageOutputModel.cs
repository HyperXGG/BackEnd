namespace WineShopApplication.Models.StorageModels
{
    public class StorageOutputModel
    {
        public int Id { get; set; }
        public required string StorageName { get; set; }
        public List<StorageInventoryModel>? Inventories { get; set; }
    }
}
