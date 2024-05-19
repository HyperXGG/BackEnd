using WineShopApplication.Repositories.Generic;
using WineShopApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace WineShopApplication.Repositories.CategoryRepo
{
    public class CategoryRepository(AlcoholManagementDbContext ctx) : GenericRepository<Category>(ctx), ICategoryRepository
    {
        public override Category GetById(int id)
        {
            Category? result = _ctx.Categories.Include(c => c.Subcategories).SingleOrDefault(c => c.CategoryId == id);

            if (result == null)
                throw new ArgumentException("The provided id doesn't exist in the database");

            return result;
        }
    }
}
