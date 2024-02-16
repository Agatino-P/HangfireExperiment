using Hangfire;

namespace HangfireExp.Api;

internal class Program
{
    public static ILogger<Program> Logger { get; set; } = default!;
    public static WebApplication app = default!;

    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.MapGet("/Enqueue", (ILogger<Program> logger) => LogSomething())
        .WithName("GetWeatherForecast")
        .WithOpenApi();

        GlobalConfiguration.Configuration
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
               .UseColouredConsoleLogProvider()
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UseSqlServerStorage("Server=localhost;Database=HangFireTestDb;User Id=sa;Password=Password1;TrustServerCertificate=True;");

        _ = new BackgroundJobServer();

        app.Run();
    }
    public static void LogSomething()
    {
        ILogger<Program> logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("From Job: {$1}", DateTime.Now.ToString("hh:mm:ss:fff"));
    }

}

