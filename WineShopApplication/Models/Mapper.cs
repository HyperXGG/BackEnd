using WineShopApplication.Data;
using WineShopApplication.Models.CategoryModels;
using WineShopApplication.Models.ProducerModels;
using WineShopApplication.Models.ProductModels;
using WineShopApplication.Models.StorageModels;
using WineShopApplication.Models.SubcategoryModels;

namespace WineShopApplication.Models
{
    public class Mapper
    {
        #region Category

        public Category MapModelToEntity(CategoryInputModel model)
        {
            return new Category
            {
                CategoryId = 0,
                Name = model.Name,
                Description = model.Description
            }; 
        }

        public CategoryOutputModel MapEntityToModel(Category entity)
        {
            return new CategoryOutputModel
            {
                Id = entity.CategoryId,
                Name = entity.Name,
                Description = entity.Description,
                Subcategories = entity.Subcategories?.Select(x => x.Name).ToList()
            };
        }

        #endregion

        #region Subcategory

        public Subcategory MapModelToEntity(SubcategoryInputModel model)
        {
            return new Subcategory
            {
                SubcategoryId = 0,
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId
            };
        }

        public SubcategoryOutputModel MapEntityToModel(Subcategory entity)
        {
            return new SubcategoryOutputModel
            {
                Id = entity.CategoryId,
                Name = entity.Name,
                Description = entity.Description,
                CategoryName = entity.Category!.Name,
                Products = entity.Products?.ConvertAll(MapProductToSubcategoryProductModel)
            };
        }

        private SubcategoryProductModel MapProductToSubcategoryProductModel(Product entity)
        {
            return new SubcategoryProductModel
            {
                Id = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price
            };
        }

        #endregion

        #region Product

        public Product MapModelToEntity(ProductInputModel model)
        {
            return new Product
            {
                ProductId = 0,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                SubcategoryId = model.SubcategoryId,
                ProducerId = model.ProducerId,
                Inventories = model.Inventories?.ConvertAll(MapModelToEntity)
            };
        }

        public ProductOutputModel MapEntityToModel(Product entity)
        {
            return new ProductOutputModel
            {
                Id = entity.ProductId,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                SubcategoryName = entity.Subcategory!.Name,
                ProducerName = entity.Producer!.Name,
                Inventories = null
            };
        }

        public Inventory MapModelToEntity(ProductInventoryInputModel model)
        {
            return new Inventory
            {
                ProductId = model.ProductId,
                StorageId = model.StorageId,
                Amount = model.Amount,
                ShelfNumber = model.ShelfNumber
            };
        }

        public ProductInventoryOutputModel MapInventoryToProductInventoryOutputModel(Inventory entity)
        {
            return new ProductInventoryOutputModel
            {
                StorageId = entity.StorageId,
                StorageName = entity.Storage?.StorageName,
                Amount = entity.Amount,
                ShelfNumber = entity.ShelfNumber
            };
        }

        #endregion

        #region Producer

        public Producer MapModelToEntity(ProducerInputModel model)
        {
            return new Producer
            {
                ProducerId = 0,
                Name = model.Name,
                Headquarter = model.Headquarter,
            };
        }

        public ProducerOutputModel MapEntityToModel(Producer entity)
        {
            return new ProducerOutputModel
            {
                Id = entity.ProducerId,
                Name = entity.Name,
                Headquarter = entity.Headquarter,
                Products = entity.Products?.ConvertAll(MapProductToProducerProductModel)
            };
        }

        private ProducerProductModel MapProductToProducerProductModel(Product entity)
        {
            return new ProducerProductModel
            {
                ProductId = entity.ProductId,
                ProductName = entity.Name,
                SubcategoryName = entity.Subcategory!.Name,
                Price = entity.Price
            };
        }

        #endregion

        #region Storage

        public StorageOutputModel MapEntityToModel(Storage entity)
        {
            return new StorageOutputModel
            {
                Id = entity.StorageId,
                StorageName = entity.StorageName,
                Inventories = entity.Inventories?.ConvertAll(MapInventoryToStorageInventoryModel)
            };
        }

        private StorageInventoryModel MapInventoryToStorageInventoryModel(Inventory entity)
        {
            return new StorageInventoryModel
            {
                ProductId = entity.ProductId,
                ProductName = entity.Product?.Name,
                Price = entity.Product?.Price,
                Amount = entity.Amount,
                ShelfNumber = entity.ShelfNumber
            };
        }

        #endregion
    }
}
