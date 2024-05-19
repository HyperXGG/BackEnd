using WineShopApplication.Data;
using WineShopApplication.Repositories.Generic;

namespace WineShopApplication.Repositories.ProducerRepo
{
    public class ProducerRepository(AlcoholManagementDbContext ctx) : GenericRepository<Producer>(ctx), IProducerRepository
    {
    }
}
