using System.Security.Cryptography;
using YourMovies.Application.Interfaces.Account.Token;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Services.Account.Token
{
    public sealed class GenerateRefreshTokenService : IGenerateRefreshTokenService
    {
        private JwtOptions _jwtOptions;

        public GenerateRefreshTokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public async Task<TokenResult> GenerateRefreshToken()
        {
            var refreshToken = new TokenResult(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                DateTime.Now.AddMinutes(_jwtOptions.RefreshTokenExpiryInMinutes));

            return refreshToken;
        }
    }
}
