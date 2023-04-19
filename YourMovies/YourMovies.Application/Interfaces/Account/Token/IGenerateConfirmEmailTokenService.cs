
using YourMovies.Domain.Entities;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Interfaces.Account.Token
{
    public interface IGenerateConfirmEmailTokenService
    {
        Task<string> GenerateConfirmEmailToken(User user);
    }
}
