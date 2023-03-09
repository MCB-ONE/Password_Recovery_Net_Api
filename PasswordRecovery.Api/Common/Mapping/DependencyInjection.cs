using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;

namespace PasswordRecovery.Api.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        // Catch the config in TypeAddapterConfig
        var config = TypeAdapterConfig.GlobalSettings;

        // Scan the assembl
        config.Scan(Assembly.GetExecutingAssembly());

        // Add the mapping config service in the ID container & the mapper service
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}