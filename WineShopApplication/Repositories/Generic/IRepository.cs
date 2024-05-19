using System.Linq.Expressions;

namespace WineShopApplication.Repositories.Generic
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        void Delete(int id);
        IQueryable<T> Filter(Expression<Func<T, bool>> filter);
    }
}
