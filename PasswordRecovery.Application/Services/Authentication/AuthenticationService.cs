using ErrorOr;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;
using PasswordRecovery.Domain.Common.Errors;
namespace PasswordRecovery.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtGenerator, IUserRepository userRepository)
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
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //TODO 1. Validate user exist & isActive = true
        if(_userRepository.GetByEmail(email) is not User user){
              return Errors.Authentication.InvalidCredentials;
        }

        
        // 2. Validate password is correct
        if(user.Password != password){
             return Errors.Authentication.InvalidCredentials;
        }

        // 3. Create JWT Token
        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}