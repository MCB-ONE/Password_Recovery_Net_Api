namespace GameOfFoodies.Contracts.Authentication;

public record RegisterRequest(
    string Nombre,
    string Apellido,
    string Email,
    string Password
);