
namespace YourMovies.Domain.Entities
{
    public class Department : Entity
    {
        public string Name { get; set; }

        public Department(Guid id) : base(id)
        {
        }
    }
}
