
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

        public void UpdateDatails(CinemaDetails details)
        {
            AgeRating = details.AgeRating;
            TypeCinema = details.TypeCinema;
            Ganre = details.Ganre;
            Country = details.Country;
            ProductionCompany = details.ProductionCompany;
            CinemaCast = details.CinemaCast;
            CinemaCrew = details.CinemaCrew;
            Name = details.Name;
            Description = details.Description;
            ReleaseDate = details.ReleaseDate;
            MainImage = details.MainImage;
            FilmBudget = details.FilmBudget;
        }

        public readonly record struct CinemaDetails
        {
            public AgeRating AgeRating { get; }

            public TypeCinema TypeCinema { get; }

            public Ganre Ganre { get; }

            public Country Country { get; }

            public ProductionCompany ProductionCompany { get; }

            public CinemaCast CinemaCast { get; }

            public CinemaCrew CinemaCrew { get; }

            public string Name { get; }

            public string Description { get; }

            public DateTime ReleaseDate { get; }

            public string MainImage { get; }

            public decimal FilmBudget { get; }

            public CinemaDetails(AgeRating ageRating, TypeCinema typeCinema,
                Ganre ganre, Country country, ProductionCompany productionCompany,
                CinemaCast cinemaCast, CinemaCrew cinemaCrew, string name,
                string description, DateTime releaseDate, string mainImage,
                decimal filmBudget)
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
}
