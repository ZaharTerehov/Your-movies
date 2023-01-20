
namespace YourMovies.Domain.Entities
{
    public class CinemaCrew : Entity
    {
        Person Person { get; set; }

        Department Department { get; set; }

        string Job { get; set; }

        public CinemaCrew(Guid id) : base(id)
        {
        }
    }
}
