
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using YourMovies.Application.Contracts.User;
using YourMovies.Application.Interfaces;
using YourMovies.Application.Interfaces.Account;
using YourMovies.Application.Interfaces.Account.Token;

namespace YourMovies.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IGenerateAccessTokenService _generateAccessToken;
        private readonly IGenerateConfirmEmailTokenService _generateConfirmEmailToken;
        private readonly IEmailSenderService _emailSender;

        public string LocationAccessToken { get; init; } = "YourMovies.Application.AT";
        public string LocationRefreshToken { get; init; } = "YourMovies.Application.RT";

        public RegisterController(IUnitOfWork unitOfWork, IMapper mapper, 
            IGenerateAccessTokenService generateAccessToken, IGenerateConfirmEmailTokenService generateConfirmEmailToken,
            IEmailSenderService emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _generateAccessToken = generateAccessToken;
            _generateConfirmEmailToken = generateConfirmEmailToken;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            //var captchaValidation = await СheckСaptchaTokenForValidity(model.ReCaptcha);
            
            //if (captchaValidation.StatusCode != StatusCode.OK)
            //    return captchaValidation;
            
            var users = await _unitOfWork.Users.GetAllAsync();

            if (users.Select(_ => _.Email == request.Email) == null)
                return BadRequest("There is already a user with this login");
            
            var newUser = _mapper.Map<Domain.Entities.User>(request);
            
            await _unitOfWork.Users.CreateAsync(newUser);
            
            var token = await GenerateEmailConfirmationToken(newUser);
            
            newUser.EmailVerificationToken = token.token;
            
            await _unitOfWork.Users.UpdateAsync(newUser);
            
            await _emailSender.SendEmailAsync(newUser.Email, "Confirm your email", "Click on the link to confirm email - " +token.link);
            
            return Ok(newUser);
        }

        private async Task<(string link, string token)> GenerateEmailConfirmationToken(Domain.Entities.User user)
        {
            var confirmEmailToken = await _generateConfirmEmailToken.GenerateConfirmEmailToken(user);

            var validEmailToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmEmailToken));

            return ($"https://localhost:7227/Account/ConfirmEmail?userid={user.Id}&token={validEmailToken}", validEmailToken);
        }
    }
}
