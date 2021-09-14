using front_end;

var builder = WebApplication.CreateBuilder(args);
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