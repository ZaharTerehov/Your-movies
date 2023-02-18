
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace YourMovies.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);

        //

        Task SaveChangesAsync();

        Task<T> First(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefault();

        Task<T> FirstOrDefaultAsync();

        Task<IQueryable<T>> GetAll();

        Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> predicate);

        Task<T> Find(params object[] keys);

        IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate);

        IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate);
    }
}
