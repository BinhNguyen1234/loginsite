using FileSericeWorker;
using Microsoft.AspNetCore.Hosting;


// Add services to the con


public class Program
{
    public static void Main(string[] args)
    {
        var builder = createWebBuilder(args);
        var startup = new Startup(builder, builder.Environment);
        startup.ConfigureServices(builder.Services);
        var app = builder.Build();
        startup.Configure(app, app.Environment);
        app.Run();
    }
    private static WebApplicationBuilder createWebBuilder(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false);
        return builder;
    }
}