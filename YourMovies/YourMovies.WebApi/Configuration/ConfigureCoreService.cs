using YourMovies.Application.Interfaces;
using YourMovies.Application.Interfaces.Account;
using YourMovies.Application.Services.Account;
using YourMovies.Infrastructure.Data;

namespace YourMovies.WebApi.Configuration
{
    public static class ConfigureCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient(typeof(IEmailSenderService), typeof(EmailSenderService));

            return services;
        }
    }
}
