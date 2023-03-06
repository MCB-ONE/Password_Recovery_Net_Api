using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;

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

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validare the user doesn't exist
        if ( _userRepository.GetByEmail(email) is not null)
        {
            throw new Exception("Ya existe un usuario con este email.");
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

        var token = _jwtGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);


        return new AuthenticationResult(
            user.Id,
            firstName,
            lastName,
            email,
            token);
    }
    public AuthenticationResult Login(string email, string password)
    {
        //TODO 1. Validate user exist & isActive = true
        if(_userRepository.GetByEmail(email) is not User user){
             throw new Exception("No existe un usuario con este email.");
        }
        // 2. Validate password is correct
        if(user.Password != password){
             throw new Exception("Contraseña incorrecta.");
        }

        // 3. Create JWT Token
        var token = _jwtGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            email,
            token);
    }
}