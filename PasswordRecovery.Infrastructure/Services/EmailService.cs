using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using PasswordRecovery.Application.Common.Interfaces.Services;

namespace PasswordRecovery.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public readonly SmtpSettings _smptSettings;

        public EmailService(IOptions<SmtpSettings> smptSettings)
        {
            _smptSettings = smptSettings.Value;
        }

        public async Task SendConfirmationEmail(string email, string confirmationLink)
        {
            // TODO 1. Handle SmtpClient connection errors
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smptSettings.FromName, _smptSettings.FromAddress));
            message.To.Add(new MailboxAddress("New user", email));
            message.Subject = "Confirm your email address";

            var builder = new BodyBuilder();
            var fullLink = "http://localhost:5237/auth/verify/"+confirmationLink;
            builder.HtmlBody = $"<p>Thank you for registering! Please confirm your email address by clicking on the following link: <a href='{fullLink}'>Confirm Email</a>.</p>";
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smptSettings.Host, _smptSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smptSettings.Username, _smptSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}