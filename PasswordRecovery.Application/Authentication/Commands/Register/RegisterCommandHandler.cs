using ErrorOr;
using MediatR;
using PasswordRecovery.Domain.Common.Errors;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;
using PasswordRecovery.Application.Authentication.Common;
using PasswordRecovery.Application.Common.Interfaces.Services;

namespace PasswordRecovery.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResult>>
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IVerificationTokenGenerator _verificationTokenGenerator;

    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jWtTokenGenerator, IVerificationTokenGenerator verificationTokenGenerator, IEmailService emailService, IUserRepository userRepository)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
        _verificationTokenGenerator = verificationTokenGenerator;
        _emailService = emailService;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<RegisterResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // 1. Validare the user doesn't exist
        if ( await _userRepository.GetByEmailAsync(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //2. Create Token for email validation & JWT Token

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

        var JwtToken = _jWtTokenGenerator.GenerateToken(user);

        user.Token = JwtToken;

        await _userRepository.AddAsync(user);

        // 4. Send the validation token to user email
        await _emailService.SendConfirmationEmail(user.Email, user.VerificationToken);

        //TODO 4. Receive the user token verification

        //TODO 5. Verify if the token is valid

        //TODO 6. Update user entity (email confirmed field)

        //TODO 7. Send email to user whit email confirmed message


        return new RegisterResult(
            "User successfully created.");
    }
}