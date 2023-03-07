using ErrorOr;
using PasswordRecovery.Domain.Entities;
using PasswordRecovery.Domain.Common.Errors;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Application.Services.Authentication.Common;

namespace PasswordRecovery.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationCommandService(IJwtTokenGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validare the user doesn't exist
        if ( _userRepository.GetByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        //TODO 2. Create User (Generate uniq id) & persist with email not confirmed field
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
            Token = false,
            IsActive = false
        };

        _userRepository.Add(user);

        //TODO 3. Create JWT Token for email validation

        //TODO 4. Send the validation token to user email

        //TODO 4. Receive the user token verification

        //TODO 5. Verify if the token is valid

        //TODO 6. Update user entity (email confirmed field)

        //TODO 7. Send email to user whit email confirmed message

        var token = _jwtGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token);
    }

}