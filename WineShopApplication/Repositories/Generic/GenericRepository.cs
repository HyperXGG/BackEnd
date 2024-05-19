using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WineShopApplication.Data;

namespace WineShopApplication.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AlcoholManagementDbContext _ctx;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AlcoholManagementDbContext ctx)
        {
            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }

        public IQueryable<T> GetAll() => _dbSet;    //.Skip(10).Take(10);

        public virtual T GetById(int id)
        {
            T? result = _dbSet.Find(id);

            if (result == null)
                throw new ArgumentException("The provided id doesn't exist in the database");

            return result;
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            T? entity = GetById(id);

            if (entity == null)
                throw new ArgumentException("The provided id doesn't exist in the database");

            _dbSet.Remove(entity);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> filter) => _dbSet.Where(filter);
    }
}
