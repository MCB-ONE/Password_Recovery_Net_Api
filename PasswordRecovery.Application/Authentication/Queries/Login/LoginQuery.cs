using ErrorOr;
using MediatR;
using PasswordRecovery.Application.Authentication.Common;

namespace PasswordRecovery.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password): IRequest<ErrorOr<AuthenticationResult>>;