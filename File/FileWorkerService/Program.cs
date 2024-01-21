using FileWorkerService;

var builder = Host.CreateApplicationBuilder(args);
var startUp = new Startup();
startUp.ConfigureServices(builder.Services);
var host = builder.Build();
host.Run();
