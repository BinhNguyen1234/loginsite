using WorkerService2;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ConsumeRabiitMQService>();

var host = builder.Build();
host.Run();
