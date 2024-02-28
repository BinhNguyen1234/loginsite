using FileSericeWorker.RabitMQ;
using FileSericeWorker.Service;
using FileWorkerService.Worker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Net.NetworkInformation;
using System.IO;
using FileSericeWorker.Service.StorageService;
using static System.Net.WebRequestMethods;
using Microsoft.Net.Http.Headers;
using System.Reflection.Metadata;
using Quartz.Util;
using System.Security.Cryptography;
namespace FileSericeWorker.Controllers
{
    [Route("[controller]/[action]")]
    public class File : ControllerBase
    {

        private readonly ILogger<File> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IRabitMqProducer _rabitMQProducer;
        private IStorageService _service;
        public File(ILogger<File> logger, IServiceProvider serviceProvider, IRabitMqProducer rabitMQProducer, IStorageService service)
        {
            _rabitMQProducer = rabitMQProducer;
            _service = service;
            _logger = logger;
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException();
        }
        [HttpPost]
        public IActionResult Mkdir([FromBody] Test test)
        {
            _rabitMQProducer.SendMessage(test);
            return Ok("ff");
        }
        [HttpPost]
        public IActionResult CreateFolder([FromBody] Test test)
        {
            _service.Test();
            _rabitMQProducer.SendMessage(test);
            return Ok("ff");
        }
        [HttpPost]
        public IActionResult MergeFile([FromBody] Test test)
        {
            _service.Test();
            _rabitMQProducer.SendMessage(test);
            return Ok("ff");
        }
        [HttpPost]
        public async Task<IActionResult> uploadFile()
        {
            //_service.Test();
            //_rabitMQProducer.SendMessage(test);
            //return Ok("ff");
            var le = HttpContext.Request.Form.Files[0];
            using (var des = System.IO.File.Create($"D://file//{le.FileName}"))
            using (Stream file = HttpContext.Request.Form.Files[0].OpenReadStream())
            {
                byte[] buffer = new byte[1024 * 1024 * 10];
                int bytesRead;

                while ((bytesRead = await file.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {

                    des.Write(buffer, 0, bytesRead);
                }
                await file.DisposeAsync();

                await des.DisposeAsync();
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult runservice()
        {
            return Ok("ff");
        }

        [HttpGet]
        public IActionResult downloadFile()
        {
            //string mimeType = "application/unknown";
            //Response.ContentType = mimeType;
            ////_service.Test();
            ////_rabitMQProducer.SendMessage(test);
            ////return Ok("ff");
            ///



            using (FileStream fsInput = new FileStream($"D://file//file_example_PNG_3MB.png", FileMode.Open))
            {
            using (FileStream fsOutput = new FileStream($"D://file//file_example_PNG_3MB-en.png", FileMode.Create))
                {
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

                        // Perform decryption
                        ICryptoTransform decryptor = aes.CreateDecryptor();
                        using (CryptoStream cs = new CryptoStream(fsOutput, decryptor, CryptoStreamMode.Write))
                        {
                            fsInput.CopyTo(cs);
                        }
                    }
                }
            }


            //return File(System.IO.File.OpenRead($"D://file//file_example_PNG_3MB.png"), System.Net.Mime.MediaTypeNames.Application.Octet, "ffff.png");
            return Ok("");
        }
        //[HttpGet]
        //public IActionResult stopservice()
        //{
        //    var schedulerFactory = _serviceProvider.GetRequiredService<ISchedulerFactory>();
        //    return Ok("ff");
        //}
    }
    public class Test
    {
        public string name { get; set; }
        public int numberOfPart { get; set; }
    }
}
