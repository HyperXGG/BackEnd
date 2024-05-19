namespace WineShopApplication.Data
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public required string Name { get; set; }
        public required string Headquarter { get; set; }
        public List<Product>? Products { get; set; }
    }
}
