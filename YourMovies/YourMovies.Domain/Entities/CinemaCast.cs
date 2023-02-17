
namespace YourMovies.Domain.Entities
{
    public class CinemaCast : Entity
    {
        public Person Person { get; set; }

        public string CharacterName { get; set; }

        public decimal CastOrder { get; set; }

        public void UpdateDetails(CinemaCastDetails details)
        {
            Person = details.Person;
            CharacterName = details.CharacterName;
            CastOrder = details.CastOrder;
        }

        public readonly record struct CinemaCastDetails
        {
            public Person Person { get; }
            public string CharacterName { get; }
            public decimal CastOrder { get; }

            public CinemaCastDetails(Person person, string characterName, decimal castOrder)
            {
                Person = person;
                CharacterName = characterName;
                CastOrder = castOrder;
            }
        }
    }
}
