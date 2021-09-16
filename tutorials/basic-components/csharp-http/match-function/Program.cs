using match_function;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

var builder = WebApplication.CreateBuilder(args);

// Adding logging to Dependency Injection
var logger = LoggerFactory.Create(
    logBuilder => logBuilder.AddConsole(
        configuration =>
        {
            configuration.TimestampFormat = "[HH:mm:ss] ";
        })
    )
    .CreateLogger("MatchFunction");
builder.Services.AddSingleton<ILogger>(logger);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Handle Exceptions
app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, ex.Message);
        await context.Response.WriteAsJsonAsync(new { Message = ex.Message });
    }
});

// Handle the creation of match proposals
app.MapPost("/v1/matchfunction:run", MatchFunction.Handle);

app.Run();