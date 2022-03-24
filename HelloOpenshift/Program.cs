var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Add HTTP GET entry point.
app.MapGet("/", () =>
{
    return "Welcome aboard! This project was created only for educational purposes.";
});

// Start running the host.
app.Run();
