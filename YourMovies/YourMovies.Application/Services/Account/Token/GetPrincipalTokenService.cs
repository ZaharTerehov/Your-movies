using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using YourMovies.Application.Interfaces.Account.Token;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Services.Account.Token
{
    public sealed class GetPrincipalTokenService : IGetPrincipalTokenService
    {
        private JwtOptions _jwtOptions;

        public GetPrincipalTokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public async Task<JwtSecurityToken> GetPrincipalToken(TokenResult token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SigningKey);

            tokenHandler.ValidateToken(token.Token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
