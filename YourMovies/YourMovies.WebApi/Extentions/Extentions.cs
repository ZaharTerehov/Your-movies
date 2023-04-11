using YourMovies.WebApi.Middleware;

namespace YourMovies.WebApi.Extentions
{
    public static class Extentions
    {
        public static void UseExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
