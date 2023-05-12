
using System.ComponentModel.DataAnnotations;
using YourMovies.Domain.Enums;

namespace YourMovies.Domain.Entities
{
    public sealed class User : Entity
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Remark must have min length of 5")]
        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public Role Role { get; set; } = Role.User;

        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryInMinutes { get; set; }

        public bool EmailIsVerified { get; set; } = false;

        public string EmailVerificationToken { get; set; } = string.Empty;

        public void UpdateDetails(UserDetails details)
        {
            Email = details.Email;
            Password = details.Password;
        }

        public void UpdateRefreshToken(string refreshToken, DateTime refreshTokenExpiryInMinutes)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpiryInMinutes = refreshTokenExpiryInMinutes;
        }
    }

    public readonly record struct UserDetails
    {
        public string Email { get; }

        public string Password { get; }

        public UserDetails(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
