using System;
using front_end;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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

app.UseForwardedHeaders();

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

app.MapGet("/", () => "Hello World!");

// Handle POST requests to create a ticket
app.MapPost("/v1/tickets", CreateTicket.Handle);

// Handle GET requests to get a ticket
app.MapGet("/v1/tickets/{ticketId}", GetTicket.Handle);

// Handle DELETE requests to delete a ticket
app.MapDelete("/v1/tickets/{ticketId}", DeleteTicket.Handle);


app.Run();