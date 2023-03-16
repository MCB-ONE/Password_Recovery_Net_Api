namespace PasswordRecovery.Application.Common.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string email, string confirmationLink);
    }
}