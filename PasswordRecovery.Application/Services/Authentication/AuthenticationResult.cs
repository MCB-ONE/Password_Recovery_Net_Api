
namespace PasswordRecovery.Application.Services.Authentication;

public record AuthenticationResult
(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string Token);
