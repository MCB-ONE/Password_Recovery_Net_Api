using ErrorOr;
using MediatR;
using PasswordRecovery.Application.Authentication.Common;

namespace PasswordRecovery.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
): IRequest<ErrorOr<AuthenticationResult>>;