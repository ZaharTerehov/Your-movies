using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YourMovies.Application.Interfaces.Account.Token;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Services.Account.Token
{
    public sealed class GenerateConfirmEmailTokenService : IGenerateConfirmEmailTokenService
    {
        private JwtOptions _jwtOptions;

        public GenerateConfirmEmailTokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public async Task<string> GenerateConfirmEmailToken(User user)
        {
            var expiration = DateTime.Now.AddMinutes(5);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.TimeOfDay.Ticks.ToString(),ClaimValueTypes.UInteger64)
            };

            var jwtToken = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                DateTime.UtcNow,
                expiration,
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SigningKey)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
