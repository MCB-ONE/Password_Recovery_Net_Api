namespace PasswordRecovery.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);