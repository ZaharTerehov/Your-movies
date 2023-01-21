
namespace YourMovies.Domain.Entities
{
    public class Cinema : Entity
    {
        public AgeRating AgeRating {get; set;} 

        public TypeCinema TypeCinema { get; set;}

        public Ganre Ganre { get; set;}

        public Country Country { get; set; }

        public ProductionCompany ProductionCompany { get; set; }

        public CinemaCast CinemaCast { get; set; }

        public CinemaCrew CinemaCrew { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string MainImage { get; set; }

        public decimal FilmBudget { get; set; }

        public Cinema(Guid id) : base(id)
        {
        }
    }
}
