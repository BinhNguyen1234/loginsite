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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace FileWorkerService.Worker
{
    public class ConsumeRabiitMQService : BackgroundService
    {
        private readonly ILogger<ConsumeRabiitMQService> _logger;
        private IConnection _connection;
        private IModel _channel;
        private IServiceProvider _serviceProvider;

        public ConsumeRabiitMQService(ILogger<ConsumeRabiitMQService> logger, IServiceProvider serviceProvider)
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
                var converter = JsonConvert.DeserializeObject<Test>(content);
                _logger.LogInformation(content);
                Console.WriteLine(content);
                //System.IO.File.Create($"D://file//{converter?.name}");
                

                    int SIZEBUFFER = 5;
                    using (var stream = System.IO.File.Create($"D://file//{converter?.name}")) { }
                    
                    bool endread = false;
                    for (var i = 0; i <= converter.numberOfPart; i++)
                    {
                        
                        using (var stream = new FileStream(path: $"D://file//{converter?.name}", mode: FileMode.Append, access: FileAccess.Write, share: FileShare.ReadWrite))
                        using (var streamRead = new FileStream(path: $"D://file//part-{i}.{converter?.name}", mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.ReadWrite))
                        do
                            {
                            byte[] buffer = new byte[SIZEBUFFER];
                            int numberRead = streamRead.Read(buffer, 0, SIZEBUFFER);
                                if (numberRead == 0) endread = true;
                                else
                                {
                                    stream.Write(buffer, 0, numberRead);
                                }

                            } while (!endread);
                        
                    }
                
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
}
