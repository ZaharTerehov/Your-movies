using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YourMovies.Application.Interfaces.Account.Token;
using YourMovies.Application.Services.Account.Token;
using YourMovies.Domain.Enums;
using YourMovies.Domain.Models;
using YourMovies.WebApi.Middleware;

namespace YourMovies.WebApi.Extentions
{
    public static class Extentions
    {
        public static void UseExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
            JwtOptions tokenOptions)
        {
            services.AddScoped<IGenerateAccessTokenService, GenerateAccessTokenService>(serviceProvider =>
                new GenerateAccessTokenService(tokenOptions));
            services.AddScoped<IGenerateConfirmEmailTokenService, GenerateConfirmEmailTokenService>(serviceProvider =>
                new GenerateConfirmEmailTokenService(tokenOptions));
            services.AddScoped<IGenerateRefreshTokenService, GenerateRefreshTokenService>(serviceProvider =>
                new GenerateRefreshTokenService(tokenOptions));
            services.AddScoped<IGetPrincipalTokenService, GetPrincipalTokenService>(serviceProvider =>
                new GetPrincipalTokenService(tokenOptions));
            services.AddScoped<IValidateAccessTokenService, ValidateAccessTokenService>(serviceProvider =>
                new ValidateAccessTokenService(tokenOptions));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                    JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateAudience = true,
                    ValidAudience = tokenOptions.Audience,

                    ValidateIssuer = true,
                    ValidIssuer = tokenOptions.Issuer,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenOptions.SigningKey)),

                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireRole(nameof(Role.User)));
                options.AddPolicy("Admin", policy => policy.RequireRole(nameof(Role.Admin)));
            });

            return services;
        }
    }
}
