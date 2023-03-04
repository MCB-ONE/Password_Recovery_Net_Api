namespace PasswordRecovery.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string Nombre,
    string Apellido,
    string Email,
    string Token
);