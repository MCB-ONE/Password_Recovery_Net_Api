

using Microsoft.Extensions.DependencyInjection;
using PasswordRecovery.Application.Services.Authentication;

namespace PasswordRecovery.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return services;
    }

}
