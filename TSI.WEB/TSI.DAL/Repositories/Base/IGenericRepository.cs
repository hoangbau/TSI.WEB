using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TSI.DAL.Repositories.Base
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        T Update(T entity);
    }
}
