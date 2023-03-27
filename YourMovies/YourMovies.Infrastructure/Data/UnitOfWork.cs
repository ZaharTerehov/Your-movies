
using YourMovies.Domain.Entities;
using YourMovies.Domain.Interfaces;

namespace YourMovies.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<AgeRating> AgeRatings { get; }
        public IRepository<Cinema> Cinema { get; }
        public IRepository<CinemaCast> CinemaCasts { get; }
        public IRepository<CinemaCrew> CinemaCrews { get; }
        public IRepository<Country> Countrys { get; }
        public IRepository<Department> Departments { get; }
        public IRepository<Ganre> Ganres { get; }
        public IRepository<Person> Persons { get; }
        public IRepository<ProductionCompany> ProductionCompanys { get; }
        public IRepository<TypeCinema> TypeCinema { get; }

        public UnitOfWork(IRepository<AgeRating> ageRatings, IRepository<Cinema> cinema, IRepository<CinemaCast> cinemaCasts, IRepository<CinemaCrew> cinemaCrews, IRepository<Country> countrys, IRepository<Department> departments, 
            IRepository<Ganre> ganres, IRepository<Person> persons, IRepository<ProductionCompany> productionCompanys, IRepository<TypeCinema> typeCinema)
        {
            AgeRatings = ageRatings;
            Cinema = cinema;
            CinemaCasts = cinemaCasts;
            CinemaCrews = cinemaCrews;
            Countrys = countrys;
            Departments = departments;
            Ganres = ganres;
            Persons = persons;
            ProductionCompanys = productionCompanys;
            TypeCinema = typeCinema;
        }
    }
}
