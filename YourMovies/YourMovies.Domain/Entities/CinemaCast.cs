
namespace YourMovies.Domain.Entities
{
    public class CinemaCast : Entity
    {
        Person Person { get; set; }

        string CharacterName { get; set; }

        decimal CastOrder { get; set; }

        public CinemaCast(Guid id, Person person, string characterName, decimal castOrder) : base(id)
        {
            Person = person;
            CharacterName = characterName;
            CastOrder = castOrder;
        }
    }
}
