using ErrorOr;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;
using PasswordRecovery.Domain.Common.Errors;
using PasswordRecovery.Application.Services.Authentication.Common;

namespace PasswordRecovery.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationQueryService(IJwtTokenGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
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