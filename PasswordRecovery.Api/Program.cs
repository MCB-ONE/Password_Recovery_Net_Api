using PasswordRecovery.Api;
using PasswordRecovery.Application;
using PasswordRecovery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var config = builder.Configuration;

    // Register each layer dependencies
    builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(config);
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
