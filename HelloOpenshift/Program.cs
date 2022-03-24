using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Initial serilog
builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Information)
    .Enrich.WithMachineName()
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Add HTTP GET entry point.
app.MapGet("/", () =>
{
    string secretMessage = builder.Configuration["SECRET_MESSAGE"];

    Log.Information($"Message: {secretMessage}");

    return "Welcome aboard! This project was created only for educational purposes.";
});

Log.Information("Starting application");
// Start running the host.
app.Run();
