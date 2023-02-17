
namespace YourMovies.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public void UpdateDetails(PersonDetails details)
        {
            Name = details.Name;
            Surname = details.Surname;
        }

        public readonly record struct PersonDetails
        {
            public string Name { get; }

            public string Surname { get; }

            public PersonDetails(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }
        }
    }
}
