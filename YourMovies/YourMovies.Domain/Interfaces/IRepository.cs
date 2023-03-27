
using System.Linq.Expressions;

namespace YourMovies.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);

        Task<T?> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
