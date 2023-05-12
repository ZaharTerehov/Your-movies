
using YourMovies.Application.Interfaces;
using YourMovies.Domain.Models;

namespace YourMovies.Application.Services.Account
{
    public sealed class ConfirmEmailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmEmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TokenResult> ConfirmEmail(Guid userId, string token)
        {
            var existingUser = await _unitOfWork.Users.GetByIdAsync(userId);

            if (existingUser != null && existingUser.EmailVerificationToken == token)
            {
                existingUser.EmailIsVerified = true;

                var result = await Authenticate(existingUser);

                existingUser.UpdateRefreshToken(result.RefreshToken.Token, result.RefreshToken.Expires);

                await _unitOfWork.Users.UpdateAsync(existingUser);

                return new BaseResponse<JwtTokenResult>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }

            return new BaseResponse<JwtTokenResult>()
            {
                Description = "User not found",
                StatusCode = StatusCode.UserNotFound
            };
        }
    }
}
