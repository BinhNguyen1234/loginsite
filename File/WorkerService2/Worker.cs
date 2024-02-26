using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace WorkerService2
{
    public class FileHandler : BackgroundService
    {
        private readonly ILogger<FileHandler> _logger;
        private IConnection _connection;
        private IModel _channel;
        private IServiceProvider _serviceProvider;

        public FileHandler(ILogger<FileHandler> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
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
                var converter = JsonSerializer.Deserialize<Test>(content);
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
            var factory = new ConnectionFactory { HostName = "localhost", Port = 3007 };
            this._connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("product", exclusive: false);
        }

    }
    public class Test
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
