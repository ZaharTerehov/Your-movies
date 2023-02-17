
namespace YourMovies.Domain.Entities
{
    public class TypeCinema : Entity
    {
        public string Name { get; set; }

        public void UpdateDetails(TypeCinemaDetails details)
        {
            Name = details.Name;    
        }

        public readonly record struct TypeCinemaDetails
        {
            public string Name { get; }

            public TypeCinemaDetails(string name)
            {
                Name = name;
            }
        }
    }
}
