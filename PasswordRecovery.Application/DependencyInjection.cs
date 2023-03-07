

using Microsoft.Extensions.DependencyInjection;
using PasswordRecovery.Application.Services.Authentication.Commands;
using PasswordRecovery.Application.Services.Authentication.Queries;

namespace PasswordRecovery.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }

}
