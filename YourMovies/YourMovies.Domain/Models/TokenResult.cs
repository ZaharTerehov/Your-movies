
namespace YourMovies.Domain.Models
{
    public sealed class TokenResult
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public TokenResult(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
