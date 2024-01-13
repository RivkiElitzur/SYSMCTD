using SYSMCTD.Models;
using System.Linq.Expressions;

namespace SYSMCTD.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Edit(TEntity entity);
        Task<bool> Delete(int id);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null);
    }
}
