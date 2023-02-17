
namespace YourMovies.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set;}
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
