using ErrorOr;
using MediatR;
using PasswordRecovery.Domain.Common.Errors;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;
using PasswordRecovery.Application.Authentication.Common;

namespace PasswordRecovery.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResult>>
{
    private readonly IVerificationTokenGenerator _verificationTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IVerificationTokenGenerator verificationTokenGenerator)
    {
        _userRepository = userRepository;
        _verificationTokenGenerator = verificationTokenGenerator;
    }
    public async Task<ErrorOr<RegisterResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;
        // 1. Validare the user doesn't exist
        if ( _userRepository.GetByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //2. Create Token for email validation

        var verificationToken = _verificationTokenGenerator.GenerateVerificationToken();

        //3. Create User (Generate uniq id) & persist with email not confirmed field
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            VerificationToken = verificationToken,
            VerifiedAt = null,
            ResetTokenExpires = null
        };

        _userRepository.Add(user);

        //TODO 4. Send the validation token to user email

        //TODO 4. Receive the user token verification

        //TODO 5. Verify if the token is valid

        //TODO 6. Update user entity (email confirmed field)

        //TODO 7. Send email to user whit email confirmed message


        return new RegisterResult(
            "User successfully created.");
    }
}