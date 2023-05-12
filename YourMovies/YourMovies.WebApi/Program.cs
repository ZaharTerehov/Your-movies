using Serilog;
using YourMovies.Domain.Models;
using YourMovies.WebApi.Configuration;
using YourMovies.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendUrl = configuration.GetValue<string>("FrontendUrl");
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000");
        });
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendUrl).AllowAnyMethod().AllowAnyHeader();
    });
});

YourMovies.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

#region
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
#endregion

builder.Services.AddCoreServices();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "YourMovies Project", Version = "v1" });
});

//JwtToken
var sectionJwtSettings = builder.Configuration.GetSection("JwtSettings");
var options = sectionJwtSettings.Get<JwtOptions>();

var jwtOptions = new JwtOptions(options.SigningKey, options.Issuer, options.Audience,
    options.AccessTokenExpiryInMinutes, options.RefreshTokenExpiryInMinutes);

builder.Services.AddJwtAuthentication(jwtOptions);

builder.Services.Configure<JwtOptions>(sectionJwtSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "Web API YourMovies";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving.");
});

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

//app.UseExceptionMiddleware();

app.Run();