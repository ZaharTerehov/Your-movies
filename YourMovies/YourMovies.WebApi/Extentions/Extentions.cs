﻿using YourMovies.WebApi.Middleware;

namespace YourMovies.WebApi.Extentions
{
    public static class Extentions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
