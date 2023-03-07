using ErrorOr;
namespace PasswordRecovery.Application.Services.Authentication;
public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string name, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
