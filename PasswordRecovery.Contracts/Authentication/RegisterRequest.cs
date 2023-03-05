namespace GameOfFoodies.Contracts.Authentication;

public record RegisterRequest(
    string Name,
    string LastName,
    string Email,
    string Password
);