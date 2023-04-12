
namespace YourMovies.Application.Contracts.User
{
    public sealed class CreateUserRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
