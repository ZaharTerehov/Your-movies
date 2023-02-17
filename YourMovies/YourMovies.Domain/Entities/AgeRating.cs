
namespace YourMovies.Domain.Entities
{
    public class AgeRating : Entity
    {
        public string Name { get; set; }

        public string ViewAge { get; set; }

        public string Description { get; set; }

        public void UpdateDatails(AgeRatingDetails details)
        {
            Name = details.Name;
            ViewAge = details.ViewAge;
            Description = details.Description;
        }

        public readonly record struct AgeRatingDetails
        {
            public string Name { get; }
            public string ViewAge { get; }
            public string Description { get; }

            public AgeRatingDetails(string name, string viewAge, string desctiption)
            {
                Name = name;
                ViewAge = viewAge;
                Description = desctiption;
            }
        }
    }
}
