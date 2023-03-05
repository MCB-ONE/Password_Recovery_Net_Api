namespace PasswordRecovery.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string Token
);