namespace PasswordRecovery.Infrastructure.Services;
public class SmtpSettings
{
    public const string SectionName = "SmtpSettings";
    public string Host { get; init; } = null!;
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string FromName { get; init; } = null!;
    public string FromAddress { get; init; } = null!;
    public string Security { get; init; } = null!;
    public int Port { get; init; }
}