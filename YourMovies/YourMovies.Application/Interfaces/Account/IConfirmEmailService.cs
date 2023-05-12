
using YourMovies.Application.Contracts;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Interfaces.Account
{
    internal interface IConfirmEmailService
    {
        Task<BaseResponse<JwtTokenResult>> ConfirmEmail(int userId, string token);
    }
}
