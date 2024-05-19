namespace WineShopApplication.Data
{
    public class Storage
    {
        public int StorageId { get; set; }
        public required string StorageName { get; set; }
        public List<Inventory>? Inventories { get; set; }
    }
}
