
namespace YourMovies.Application.Interfaces.Account
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(string email, string header, string message);
    }
}
