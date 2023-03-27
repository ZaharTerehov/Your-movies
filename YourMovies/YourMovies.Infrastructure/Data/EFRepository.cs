
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;
using YourMovies.Infrastructure.Data.DBExtentions;

namespace YourMovies.Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T> where T : Entity
    {
        private readonly YourMoviesContext _dbYourMoviesContext;
        public EFRepository(YourMoviesContext dbYourMoviesContext)
        {
            _dbYourMoviesContext = dbYourMoviesContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.DateCreated = DateTime.Now;
            entity.Id = Guid.NewGuid();
            _dbYourMoviesContext.Add(entity);
            await _dbYourMoviesContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            T? entity = await _dbYourMoviesContext.Set<T>().FindAsync(id);

            if(entity is null)
                return;
            
            _dbYourMoviesContext.Set<T>().Remove(entity);
            await _dbYourMoviesContext.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbYourMoviesContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var entities = await _dbYourMoviesContext.Set<T>().IncludeFields(includes).FirstOrDefaultAsync(x => x.Id == id);
            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            entity.DateUpdated = DateTime.UtcNow;
            _dbYourMoviesContext.Update(entity);
            await _dbYourMoviesContext.SaveChangesAsync();
        }
    }
}
