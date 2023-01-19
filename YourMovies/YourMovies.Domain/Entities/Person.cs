
namespace YourMovies.Domain.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Person(Guid id) : base(id)
        {
        }
    }
}
