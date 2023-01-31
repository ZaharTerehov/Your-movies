
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

        public Cinema(Guid id, AgeRating ageRating, TypeCinema typeCinema, Ganre ganre,
            Country country, ProductionCompany productionCompany, CinemaCast cinemaCast,
            CinemaCrew cinemaCrew, string name, string description, DateTime releaseDate,
            string mainImage, decimal filmBudget) : base(id)
        {
            AgeRating = ageRating;
            TypeCinema = typeCinema;
            Ganre = ganre;
            Country = country;
            ProductionCompany = productionCompany;
            CinemaCast = cinemaCast;
            CinemaCrew = cinemaCrew;
            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            MainImage = mainImage;
            FilmBudget = filmBudget;
        }
    }
}
