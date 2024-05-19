using WineShopApplication.Repositories.CategoryRepo;
using WineShopApplication.Repositories.ProducerRepo;
using WineShopApplication.Repositories.ProductRepo;
using WineShopApplication.Repositories.StorageRepo;
using WineShopApplication.Repositories.SubcategoryRepo;

namespace WineShopApplication.Repositories._UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ISubcategoryRepository SubcategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProducerRepository ProducerRepository { get; }
        IStorageRepository StorageRepository { get; }

        bool Commit();
    }
}
