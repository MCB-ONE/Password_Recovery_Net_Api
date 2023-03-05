namespace PasswordRecovery.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string name, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}
