using WineShopApplication.Data;
using WineShopApplication.Repositories.CategoryRepo;
using WineShopApplication.Repositories.ProducerRepo;
using WineShopApplication.Repositories.ProductRepo;
using WineShopApplication.Repositories.StorageRepo;
using WineShopApplication.Repositories.SubcategoryRepo;

namespace WineShopApplication.Repositories._UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlcoholManagementDbContext _ctx;

        public ICategoryRepository CategoryRepository { get; init; }
        public ISubcategoryRepository SubcategoryRepository { get; init; }
        public IProductRepository ProductRepository { get; init; }
        public IProducerRepository ProducerRepository { get; init; }
        public IStorageRepository StorageRepository { get; init; }

        public UnitOfWork(AlcoholManagementDbContext ctx)
        {
            _ctx = ctx;

            CategoryRepository = new CategoryRepository(ctx);
            SubcategoryRepository = new SubcategoryRepository(ctx);
            ProductRepository = new ProductRepository(ctx);
            ProducerRepository = new ProducerRepository(ctx);
            StorageRepository = new StorageRepository(ctx);
        }

        public bool Commit() => _ctx.SaveChanges() > 0;
    }
}
