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
using System.Security.Cryptography;

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


                //using (var ddd = System.IO.File.Create($"D://file//{converter?.name}")) { }
                //using (var stream = new FileStream(path: $"D://file//{converter?.name}", mode: FileMode.Append, access: FileAccess.Write, share: FileShare.ReadWrite))
                //using (StreamWriter sw = new StreamWriter(stream))
                //{
                //for (var i = 0; i <= converter.numberOfPart; i++)
                //{
                //    using (var streamRead = System.IO.File.OpenRead(path: $"D://file//part-{i}.{converter?.name}"))
                //    {
                //        streamRead.CopyTo(stream);
                //    }
                //}



                using (var ddd = System.IO.File.Create($"D://file//{converter?.name}")) { }


                using (var stream = new FileStream(path: $"D://file//{converter?.name}", mode: FileMode.Append, access: FileAccess.Write, share: FileShare.ReadWrite))
                {
                    for (var i = 0; i <= converter.numberOfPart; i++)
                    {
                        using (var streamRead = new FileStream(path: $"D://file//part-{i}.{converter?.name}", mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.ReadWrite))
                        {
                            //streamRead.CopyTo(stream);
                            using (AesManaged aes = new AesManaged())
                            {
                                aes.Key = [91,
38,
236,
114,
205,
233,
94,
59,
70,
36,
63,
75,
106,
69,
73,
141,
10,
169,
85,
146,
127,
32,
242,
200,
84,
142,
178,
99,
42,
1,
58,
48,
];
                                aes.IV = [216,
174,
136,
238,
143,
98,
251,
49,
141,
246,
74,
49,
161,
169,
186,
137,
];
                                
                                // Perform encryption
                                ICryptoTransform encryptor = aes.CreateEncryptor();
                                using (CryptoStream cs = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                                {
                                    streamRead.CopyTo(cs);
                                }
                            }
                        }
                    }


                }



                //using (FileStream writeStream = new FileStream(path: $"D://file//{converter?.name}", mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite, share: FileShare.ReadWrite))
                //{
                //    for (var i = 0; i <= converter.numberOfPart; i++)
                //    {
                //        using (FileStream readStream = new FileStream(path: $"D://file//part-{i}.{converter?.name}", mode: FileMode.Open, access: FileAccess.ReadWrite, share: FileShare.ReadWrite))
                //        {
                //            BinaryReader reader = new BinaryReader(readStream);
                //            BinaryWriter writer = new BinaryWriter(writeStream);


                //            using (AesManaged aes = new AesManaged())
                //            {
                //                aes.Key = [0, 0, 0, 25];
                //                aes.IV = [0, 0, 0, 26];
                //                // Perform encryption
                //                ICryptoTransform encryptor = aes.CreateEncryptor();
                //                using (CryptoStream cs = new CryptoStream(writeStream, encryptor, CryptoStreamMode.Write))
                //                {
                //                    readStream.CopyTo(cs);
                //                }
                //            }


                            //// create a buffer to hold the bytes 
                            //byte[] buffer = new Byte[1024];
                            //int bytesRead;

                            //// while the read method returns bytes
                            //// keep writing them to the output stream
                            //while ((bytesRead =

                            //        readStream.Read(buffer, 0, 1024)) > 0)
                            //{
                            //    writeStream.Write(buffer, 0, bytesRead);
                            //}
                        //}
                    //}
                //}


                //using (FileStream writeStream = System.IO.File.OpenWrite($"D://file//{converter?.name}"))
                //{
                //    for (var i = 0; i <= converter.numberOfPart; i++)
                //    {
                //        using (FileStream readStream = System.IO.File.OpenRead($"D://file//part-{i}.{converter?.name}"))
                //        {
                //            BinaryReader reader = new BinaryReader(readStream);
                //            BinaryWriter writer = new BinaryWriter(writeStream);

                //            // create a buffer to hold the bytes 
                //            byte[] buffer = new Byte[1024];
                //            int bytesRead;

                //            // while the read method returns bytes
                //            // keep writing them to the output stream
                //            while ((bytesRead =
                //                    readStream.Read(buffer, 0, 1024)) > 0)
                //            {
                //                writeStream.Write(buffer, 0, bytesRead);
                //            }
                //        }
                //    }
                //}



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
