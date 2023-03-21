
namespace YourMovies.Domain.Entities
{
    public class CinemaCast : Entity
    {
        public Person? Person { get; set; }

        public Guid PersonId { get; set; }

        public Cinema? Cinema { get; set; }

        public Guid CinemaId { get; set; }

        public string? CharacterName { get; set; }

        public decimal? CastOrder { get; set; }

        public void UpdateDetails(CinemaCastDetails details)
        {
            PersonId = details.PersonId;
            Person = details.Person;
            CinemaId = details.CinemaId;
            Cinema = details.Cinema;
            CharacterName = details.CharacterName;
            CastOrder = details.CastOrder;
        }

        public readonly record struct CinemaCastDetails
        {
            public Person Person { get; }
            public Guid PersonId { get; }
            public Cinema Cinema { get; }
            public Guid CinemaId { get; }
            public string CharacterName { get; }
            public decimal CastOrder { get; }

            public CinemaCastDetails(Person person, Guid personId, Cinema cinema, Guid cinemaId, string characterName, decimal castOrder)
            {
                Person = person;
                PersonId = personId;
                Cinema = cinema;
                CinemaId = cinemaId;
                CharacterName = characterName;
                CastOrder = castOrder;
            }
        }
    }
}
