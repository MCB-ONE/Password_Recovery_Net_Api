using ErrorOr;
using MediatR;
using PasswordRecovery.Application.Authentication.Common;

namespace PasswordRecovery.Application.Authentication.Commands.Verify
{
    public record VerifyCommand(
        string VerificationToken
    ): IRequest<ErrorOr<RegisterResult>>;
}