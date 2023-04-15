
using System.IdentityModel.Tokens.Jwt;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Interfaces.Account.Token
{
    public interface IGetPrincipalTokenService
    {
        Task<JwtSecurityToken> GetPrincipalToken(TokenResult token);
    }
}
