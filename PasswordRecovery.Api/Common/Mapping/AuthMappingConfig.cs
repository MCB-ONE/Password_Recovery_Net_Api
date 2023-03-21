using Mapster;
using PasswordRecovery.Application.Authentication.Commands.Register;
using PasswordRecovery.Application.Authentication.Commands.Verify;
using PasswordRecovery.Application.Authentication.Common;
using PasswordRecovery.Application.Authentication.Queries.Login;
using PasswordRecovery.Contracts.Authentication;

namespace PasswordRecovery.Api.Common.Mapping;
public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>().MapToConstructor(true);
        config.NewConfig<VerifyRequest, VerifyCommand>().MapToConstructor(true);
        config.NewConfig<LoginRequest, LoginQuery>().MapToConstructor(true);
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User)
        .MapToConstructor(true);
    }
}