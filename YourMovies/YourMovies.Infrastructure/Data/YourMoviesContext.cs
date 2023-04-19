
using Microsoft.EntityFrameworkCore;
using YourMovies.Domain.Entities;

namespace YourMovies.Infrastructure.Data
{
    public class YourMoviesContext : DbContext
    {
        public DbSet<AgeRating> AgeRatings { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<CinemaCast> CinemaCast { get; set; }
        public DbSet<CinemaCrew> CinemaCrew { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Ganre> Ganre { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<ProductionCompany> ProductionCompany { get; set; }
        public DbSet<TypeCinema> TypeCinema { get; set; }
        public DbSet<User> Users { get; set; }

        public YourMoviesContext(DbContextOptions<YourMoviesContext> options) : base(options) { }
    }
}
