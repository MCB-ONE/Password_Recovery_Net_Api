using ErrorOr;
using PasswordRecovery.Application.Services.Authentication.Common;

namespace PasswordRecovery.Application.Services.Authentication.Queries;
public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
