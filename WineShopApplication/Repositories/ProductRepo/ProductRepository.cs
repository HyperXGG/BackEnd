using WineShopApplication.Data;
using WineShopApplication.Repositories.Generic;

namespace WineShopApplication.Repositories.ProductRepo
{
    public class ProductRepository(AlcoholManagementDbContext ctx) : GenericRepository<Product>(ctx), IProductRepository
    {
    }
}
