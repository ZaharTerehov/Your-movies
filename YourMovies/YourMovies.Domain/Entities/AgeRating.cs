
namespace YourMovies.Domain.Entities
{
    public class AgeRating : Entity
    {
        public string Name { get; private set; }

        public string ViewAge { get; private set; }

        public string Description { get; private set; }

        public AgeRating(Guid id, string name, string viewAge, string desctiption) : base(id)
        {
            Name = name;
            ViewAge = viewAge;
            Description = desctiption;
        }
    }
}
