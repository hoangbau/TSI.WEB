using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TSI.DAL.DataContext;

namespace TSI.DAL.Repositories.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TSIDataContext _dbContext;
        protected readonly IDbSet<T> _dbset;
        public GenericRepository(TSIDataContext dataContext)
        {
            _dbContext = dataContext;
            _dbset = _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable();
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.FirstOrDefaultAsync(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }

        public T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
