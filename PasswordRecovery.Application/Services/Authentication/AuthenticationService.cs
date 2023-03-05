namespace PasswordRecovery.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string name, string lastName, string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            name,
            lastName,
            email,
            "token");
    }
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "name",
            "lastName",
            email,
            "token");
    }
}