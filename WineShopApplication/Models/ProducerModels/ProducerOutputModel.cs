namespace WineShopApplication.Models.ProducerModels
{
    public class ProducerOutputModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Headquarter { get; set; }
        public List<ProducerProductModel>? Products { get; set; }
    }
}
