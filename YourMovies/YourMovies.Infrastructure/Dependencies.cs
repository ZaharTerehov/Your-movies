using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourMovies.Infrastructure.Data;

namespace YourMovies.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<YourMoviesContext>(context =>
            context.UseSqlServer(configuration.GetConnectionString("YourMoviesConnection")));
        }
    }
}
