using ErrorOr;
using MediatR;
using PasswordRecovery.Domain.Common.Errors;
using PasswordRecovery.Application.Authentication.Common;
using PasswordRecovery.Application.Common.Interfaces.Persistence;

namespace PasswordRecovery.Application.Authentication.Commands.Verify
{
    public class VerifyCommandHandler : IRequestHandler<VerifyCommand, ErrorOr<RegisterResult>>
    {
        private readonly IUserRepository _userRepository;

        public VerifyCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<RegisterResult>> Handle(VerifyCommand command, CancellationToken cancellationToken)
        {

            //1. Verify if the token is valid
            var user = await _userRepository.GetByVerifyTokenAsync(command.VerificationToken);
            if (user is null)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.VerificationToken != command.VerificationToken)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //2. Update user entity (email confirmed field)
            user.VerifiedAt = DateTime.UtcNow;
            user.VerificationToken = null;

            await _userRepository.UpdateAsync(user);
            
            return new RegisterResult(
            "User email successfully verified.");
        }
    }
}