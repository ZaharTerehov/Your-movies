
namespace YourMovies.Domain.Entities
{
    public class CinemaCast : Entity
    {
        Person Person { get; set; }

        string CharacterName { get; set; }

        decimal CastOrder { get; set; }

        public CinemaCast(Guid id) : base(id)
        {
        }
    }
}
