using ErrorOr;
using PasswordRecovery.Application.Services.Authentication.Common;

namespace PasswordRecovery.Application.Services.Authentication.Commands;
public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string name, string lastName, string email, string password);

}
