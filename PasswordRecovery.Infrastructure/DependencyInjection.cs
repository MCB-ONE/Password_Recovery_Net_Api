
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PasswordRecovery.Application.Common.Interfaces.Authentication;
using PasswordRecovery.Application.Common.Interfaces.Persistence;
using PasswordRecovery.Application.Common.Interfaces.Services;
using PasswordRecovery.Infrastructure.Authentication;
using PasswordRecovery.Infrastructure.Persistence;
using PasswordRecovery.Infrastructure.Services;

namespace PasswordRecovery.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {   
        services.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IVerificationTokenGenerator, VerificationTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

}