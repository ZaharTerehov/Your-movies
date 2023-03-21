
namespace YourMovies.Domain.Entities
{
    public class Cinema : Entity
    {
        public AgeRating? AgeRating {get; set;} 

        public Guid AgeRatingId {get; set;} 

        public TypeCinema? TypeCinema { get; set;}

        public Guid TypeCinemaId { get; set;}

        public Ganre? Ganre { get; set;}

        public Guid GanreId { get; set;}

        public Country? Country { get; set; }

        public Guid CountryId { get; set; }

        public ProductionCompany? ProductionCompany { get; set; }

        public Guid ProductionCompanyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string MainImage { get; set; }

        public decimal FilmBudget { get; set; }

        public void UpdateDatails(CinemaDetails details)
        {
            AgeRating = details.AgeRating;
            AgeRatingId = details.AgeRatingId;
            TypeCinema = details.TypeCinema;
            TypeCinemaId = details.TypeCinemaId;
            Ganre = details.Ganre;
            GanreId = details.GanreId;
            Country = details.Country;
            CountryId = details.CountryId;
            ProductionCompany = details.ProductionCompany;
            ProductionCompanyId = details.ProductionCompanyId;
            Name = details.Name;
            Description = details.Description;
            ReleaseDate = details.ReleaseDate;
            MainImage = details.MainImage;
            FilmBudget = details.FilmBudget;
        }

        public readonly record struct CinemaDetails
        {
            public AgeRating AgeRating { get; }

            public Guid AgeRatingId { get; }

            public TypeCinema TypeCinema { get; }

            public Guid TypeCinemaId { get; }

            public Ganre Ganre { get; }

            public Guid GanreId { get; }

            public Country Country { get; }

            public Guid CountryId { get; }

            public ProductionCompany ProductionCompany { get; }

            public Guid ProductionCompanyId { get; }

            public string Name { get; }

            public string Description { get; }

            public DateTime ReleaseDate { get; }

            public string MainImage { get; }

            public decimal FilmBudget { get; }

            public CinemaDetails(AgeRating ageRating, Guid ageRatingId, TypeCinema typeCinema, Guid typeCinemaId,
                Ganre ganre, Guid ganreId, Country country, Guid countryId, ProductionCompany productionCompany,
                Guid productionCompanyId, string name, string description, DateTime releaseDate, string mainImage, 
                decimal filmBudget)
            {
                AgeRating = ageRating;
                AgeRatingId = ageRatingId;
                TypeCinema = typeCinema;
                TypeCinemaId = typeCinemaId;
                Ganre = ganre;
                GanreId = ganreId;
                Country = country;
                CountryId = countryId;
                ProductionCompany = productionCompany;
                ProductionCompanyId = productionCompanyId;
                Name = name;
                Description = description;
                ReleaseDate = releaseDate;
                MainImage = mainImage;
                FilmBudget = filmBudget;
            }
        }
    }
}
