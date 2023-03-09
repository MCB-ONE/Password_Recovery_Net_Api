using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PasswordRecovery.Api.Common.Errors;
using PasswordRecovery.Api.Common.Mapping;

namespace PasswordRecovery.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
        
        services.AddMappings();
        return services;
    }

}
