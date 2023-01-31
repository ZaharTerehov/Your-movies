
namespace YourMovies.Domain.Entities
{
    public class TypeCinema : Entity
    {
        public string Name { get; set; }

        public TypeCinema(Guid id, string name) : base(id)
        {
            Name = name;    
        }
    }
}
