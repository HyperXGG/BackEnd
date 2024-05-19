using WineShopApplication.Data;
using WineShopApplication.Repositories.Generic;

namespace WineShopApplication.Repositories.StorageRepo
{
    public class StorageRepository(AlcoholManagementDbContext ctx) : GenericRepository<Storage>(ctx), IStorageRepository
    {
    }
}
