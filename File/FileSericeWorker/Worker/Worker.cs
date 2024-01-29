using FileSericeWorker.Test;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using FileSericeWorker.Controllers;
using Microsoft.Extensions.Logging;

namespace FileWorkerService.Worker
{
    //public class TaskProcessor : BackgroundService
    //{
    //    private readonly TasksToRun _tasks;

    //    public TaskProcessor(TasksToRun tasks) => _tasks = tasks;

    //    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        await Task.Yield(); // This will prevent background service from blocking start up of application

    //        while (stoppingToken.IsCancellationRequested == false)
    //        {
    //            try
    //            {
    //                var taskToRun = _tasks.Dequeue(_tokenSource.Token);


    //                await ExecuteTask(taskToRun);
    //            }
    //            catch (OperationCanceledException)
    //            {
    //                // execution cancelled
    //            }
    //            catch (Exception e)
    //            {
    //                // Catch and log all exceptions,
    //                // So we can continue processing other tasks
    //            }
    //        }
    //    }
    //}

    public class Worker1 : BackgroundService
    {
        private readonly ILogger<Worker1> _logger;
        private readonly IServiceProvider _serviceProvider;
        public Worker1(ILogger<Worker1> logger, IServiceProvider services)
        {
            _logger = logger;
            _serviceProvider = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
        private void DoSt()
        {
            Console.WriteLine("ffff");
        }
    }
    public class Worker2 : IHostedService
    {
        private readonly ILogger<Worker2> _logger;

        public Worker2(ILogger<Worker2> logger)
        {
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker2 running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public class ConsumeRabiitMQService : BackgroundService
    {
        private readonly ILogger<ConsumeRabiitMQService> _logger;
        private IConnection _connection;
        private IModel _channel;
        private IServiceProvider _serviceProvider;

        public ConsumeRabiitMQService(ILogger<ConsumeRabiitMQService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            Console.WriteLine("ffff");
            Configure();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (_, ea) =>
            {
                var body = ea.Body.ToArray();
                var content = Encoding.UTF8.GetString(body);
                var converter = JsonConvert.DeserializeObject<Test>(content);
                _logger.LogInformation(converter.age.ToString());
                _logger.LogInformation(content);
                Console.WriteLine(content);
            };
            consumer.Registered += (_, EventArgs) =>
            {
                _logger.LogInformation("Consumer was register");
                Console.WriteLine("Consumer was register");

            };
            _channel.BasicConsume("product", false, consumer);
            await Task.CompletedTask;
        }
        private void Configure()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            this._connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("product", exclusive: false);
        }
    }
}
