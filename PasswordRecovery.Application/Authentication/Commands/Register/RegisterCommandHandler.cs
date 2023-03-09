using ErrorOr;
using MediatR;
using PasswordRecovery.Domain.Common.Errors;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;
using PasswordRecovery.Application.Authentication.Common;

namespace PasswordRecovery.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jWtTokenGenerator, IUserRepository userRepository)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;
        // 1. Validare the user doesn't exist
        if ( _userRepository.GetByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        //TODO 2. Create User (Generate uniq id) & persist with email not confirmed field
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            ActivateToken = "TODO",
            IsActive = false
        };

        _userRepository.Add(user);

        //TODO 3. Create JWT Token for email validation

        //TODO 4. Send the validation token to user email

        //TODO 4. Receive the user token verification

        //TODO 5. Verify if the token is valid

        //TODO 6. Update user entity (email confirmed field)

        //TODO 7. Send email to user whit email confirmed message

        var token = _jWtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token);
    }
}