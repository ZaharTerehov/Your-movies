
using YourMovies.Domain.Models;

namespace YourMovies.Application.Interfaces.Account.Token
{
    public interface IGenerateRefreshTokenService
    {
        Task<TokenResult> GenerateRefreshToken();
    }
}
