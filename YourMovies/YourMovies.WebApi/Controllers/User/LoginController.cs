
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using YourMovies.Application.Contracts;
using YourMovies.Application.Contracts.User;
using YourMovies.Application.Helpers;
using YourMovies.Application.Interfaces;
using YourMovies.Application.Interfaces.Account;
using YourMovies.Application.Interfaces.Account.Token;
using YourMovies.Domain.Entities;
using YourMovies.Domain.Models;

namespace YourMovies.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IGenerateConfirmEmailTokenService _generateConfirmEmailToken;
        private readonly IEmailSenderService _emailSender;

        private readonly IGenerateAccessTokenService _generateAccessToken;
        private readonly IGenerateRefreshTokenService _generateRefreshToken;

        public string LocationAccessToken { get; init; } = "Booking.Application.Id";
        public string LocationRefreshToken { get; init; } = "Booking.Application.IdR";

        public LoginController(IUnitOfWork unitOfWork, IMapper mapper, IGenerateConfirmEmailTokenService generateConfirmEmailToken, IEmailSenderService emailSender, IGenerateAccessTokenService generateAccessToken, IGenerateRefreshTokenService generateRefreshToken)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _generateConfirmEmailToken = generateConfirmEmailToken;
            _emailSender = emailSender;
            _generateAccessToken = generateAccessToken;
            _generateRefreshToken = generateRefreshToken;
        }

        [HttpPost]
        public async Task<IActionResult> Login(CreateUserRequest request)
        {
            //var captchaValidation = await СheckСaptchaTokenForValidity(model.ReCaptcha)

            //if (captchaValidation.StatusCode != StatusCode.OK)
            //    return captchaValidation;

            List<Domain.Entities.User>? users = await _unitOfWork.Users.GetAllAsync() as List<Domain.Entities.User>;

            var user = users.Find(_ => _.Email == request.Email);

            if (user == null)
                return BadRequest("User is not found");

            if (user.Password != HashPasswordHelper.HashPassword(request.Password))
                return BadRequest("Invalid password or login");

            if (!user.EmailIsVerified)
            {
                var token = await GenerateEmailConfirmationToken(user);

                user.EmailVerificationToken = token.token;

                await _unitOfWork.Users.UpdateAsync(user);

                await _emailSender.SendEmailAsync(user.Email, "Confirm your email", "Click on the link to confirm email - " + token.link);

                return BadRequest("Confirm your email");
            }

            var result = await Authenticate(user);

            var existingUser = await _unitOfWork.Users.GetByIdAsync(user.Id);
            existingUser.UpdateRefreshToken(result.RefreshTokenResult.Token, result.RefreshTokenResult.Expires);

            await _unitOfWork.Users.UpdateAsync(existingUser);

            return Ok(result);
        }

        private async Task<(string link, string token)> GenerateEmailConfirmationToken(Domain.Entities.User user)
        {
            var confirmEmailToken = await _generateConfirmEmailToken.GenerateConfirmEmailToken(user);

            var validEmailToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmEmailToken));

            return ($"https://localhost:7227/Account/ConfirmEmail?userid={user.Id}&token={validEmailToken}", validEmailToken);
        }

        private async Task<JwtTokenResult> Authenticate(Domain.Entities.User user)
        {
            var tokenResult = await _generateAccessToken.GenerateAccessToken(user);

            var refreshToken = await _generateRefreshToken.GenerateRefreshToken();

            return new JwtTokenResult()
            {
                AccessTokenResult = tokenResult,
                RefreshTokenResult = refreshToken,
            };
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete(LocationAccessToken);
            HttpContext.Response.Cookies.Delete(LocationRefreshToken);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        private async Task<IActionResult> SetAccessTokenAndRefreshToken(JwtTokenResult jwtToken)
        {
            HttpContext.Response.Cookies.Append(LocationAccessToken, jwtToken.AccessTokenResult.Token,
            new CookieOptions
            {
                Expires = jwtToken.RefreshTokenResult.Expires
            });

            HttpContext.Response.Cookies.Append(LocationRefreshToken, jwtToken.RefreshTokenResult.Token,
            new CookieOptions
            {
                Expires = jwtToken.RefreshTokenResult.Expires
            });

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(Guid userId, string token)
        {
            var result = await ConfirmEmail(userId, token);

            if (result.StatusCode == ApplicationCore.Enum.StatusCode.OK)
            {
                await SetAccessTokenAndRefreshToken(result.Data);
                return Content("<html><h1><string>Your email has been verified</strong></h1></html>", "text/html");
            }

            return BadRequest(result);
        }
    }
}
