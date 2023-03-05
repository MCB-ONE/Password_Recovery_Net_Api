using PasswordRecovery.Application.Common.Interfaces.Authentication;

namespace PasswordRecovery.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtGenerator)
    {
        _jwtGenerator = jwtGenerator;
    }

    public AuthenticationResult Register(string name, string lastName, string email, string password)
    {
        // TODO: Check usuer already exist

        // Create User (Generate uniq id)
        var userId = Guid.NewGuid();

        // Create JWT Token
        var token = _jwtGenerator.GenerateToken(userId, name, lastName);


        return new AuthenticationResult(
            Guid.NewGuid(),
            name,
            lastName,
            email,
            token);
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