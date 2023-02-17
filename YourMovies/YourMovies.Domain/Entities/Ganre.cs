
namespace YourMovies.Domain.Entities
{
    public class Ganre : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public void UpdateDetails(GanreDetails details)
        {
            Name = details.Name;
            Description = details.Description;
        }

        public readonly record struct GanreDetails
        {
            public string Name { get; }

            public string Description { get; }

            public GanreDetails(string name, string description)
            {
                Name = name;
                Description = description;
            }
        }
    }
}
