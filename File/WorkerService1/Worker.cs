using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace WorkerService1
{
    public class ConsumeRabiitMQService : BackgroundService
    {
        private readonly ILogger<ConsumeRabiitMQService> _logger;
        private  IConnection _connection;
        private IModel _channel;

        public ConsumeRabiitMQService(ILogger<ConsumeRabiitMQService> logger)
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
                _logger.LogInformation(content);
            };
            consumer.Registered += (_, EventArgs) =>
            {
                _logger.LogInformation("Consumer was register");
            };
            await Task.CompletedTask;
        }
        private void Configure()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            this._connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "MergeFile",durable: false, exclusive: false, autoDelete: false);
        }
    }
}
