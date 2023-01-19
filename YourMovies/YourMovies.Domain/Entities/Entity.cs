
namespace YourMovies.Domain.Entities
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set;}

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
