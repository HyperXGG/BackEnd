using Microsoft.EntityFrameworkCore;

namespace WineShopApplication.Data
{
    [PrimaryKey(nameof(ProductId), nameof(StorageId))]
    public class Inventory
    {
        public int Amount { get; set; }
        public int ShelfNumber { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int StorageId { get; set; }
        public Storage? Storage { get; set; }
    }
}
