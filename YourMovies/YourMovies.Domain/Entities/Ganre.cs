
namespace YourMovies.Domain.Entities
{
    public class Ganre : Entity
    {
        string Name { get; set; }

        public string Description { get; set; }

        public Ganre(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
