using ErrorOr;
using MediatR;
using PasswordRecovery.Application.Authentication.Common;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Domain.Entities;

namespace PasswordRecovery.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        //TODO 1. Validate user exist & isActive = true
        if(_userRepository.GetByEmail(query.Email) is not User user){
              return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }

        
        // 2. Validate password is correct
        if(user.Password != query.Password){
             return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }

        // 3. Create JWT Token
        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
