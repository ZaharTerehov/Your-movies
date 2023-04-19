
using YourMovies.Domain.Models;

namespace YourMovies.Application.Interfaces.Account.Token
{
    public interface IValidateAccessTokenService
    {
        Task<bool> ValidateAccessToken(TokenResult token);
    }
}
