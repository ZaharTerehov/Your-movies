
using YourMovies.Domain.Entities;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Interfaces.Account.Token
{
    public interface IGenerateAccessTokenService
    {
        Task<TokenResult> GenerateAccessToken(User user);
    }
}
