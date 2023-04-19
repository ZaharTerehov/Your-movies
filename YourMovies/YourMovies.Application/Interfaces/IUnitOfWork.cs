
using YourMovies.Domain.Entities;

namespace YourMovies.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<AgeRating> AgeRatings { get; }
        IRepository<Cinema> Cinema { get; }
        IRepository<CinemaCast> CinemaCasts { get; }
        IRepository<CinemaCrew> CinemaCrews { get; }
        IRepository<Country> Countrys { get; }
        IRepository<Department> Departments { get; }
        IRepository<Ganre> Ganres { get; }
        IRepository<Person> Persons { get; }
        IRepository<ProductionCompany> ProductionCompanys { get; }
        IRepository<TypeCinema> TypeCinema { get; }
        IRepository<User> Users { get; }
    }
}
