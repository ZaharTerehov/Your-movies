using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YourMovies.Application.Interfaces.Account.Token;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Services.Account.Token
{
    public sealed class ValidateAccessTokenService : IValidateAccessTokenService
    {
        private JwtOptions _jwtOptions;

        public ValidateAccessTokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public async Task<bool> ValidateAccessToken(TokenResult token)
        {
            ClaimsPrincipal principal;

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadToken(token.Token) as JwtSecurityToken;
            
            if(jwtToken != null)
            {
                var symmetricKey = Encoding.ASCII.GetBytes(_jwtOptions.SigningKey);
            
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };
            
                SecurityToken securityToken;
                principal = tokenHandler.ValidateToken(token.Token, validationParameters, out securityToken);
            
                return true;
            }

            return false;
        }
    }
}
