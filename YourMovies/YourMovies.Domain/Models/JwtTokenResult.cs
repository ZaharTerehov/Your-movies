
namespace YourMovies.Domain.Models
{
    public sealed class JwtTokenResult
    {
        public TokenResult AccessTokenResult { get; set; }
        public TokenResult RefreshTokenResult { get; set; }
    }
}
