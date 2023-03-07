using Microsoft.AspNetCore.Mvc.Infrastructure;
using PasswordRecovery.Api.Common.Errors;
using PasswordRecovery.Application;
using PasswordRecovery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var config = builder.Configuration;

    builder.Services
    .AddApplication()
    .AddInfrastructure(config);

    builder.Services.AddControllers();

    // Overwrite Problem Details Factory with Custom Problem Details Factory from global error handling 
    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
