using WineShopApplication.Data;
using WineShopApplication.Repositories.Generic;

namespace WineShopApplication.Repositories.SubcategoryRepo
{
    public class SubcategoryRepository(AlcoholManagementDbContext ctx) : GenericRepository<Subcategory>(ctx), ISubcategoryRepository
    {
    }
}
