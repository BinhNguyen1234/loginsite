using FileSericeWorker.RabitMQ;
using FileSericeWorker.Service;
using FileWorkerService.Worker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Net.NetworkInformation;
using System.IO;
using FileSericeWorker.Service.StorageService;
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
        //[HttpGet]
        //public IActionResult runservice()
        //{
        //    _backgroundTaskQueue.EnqueueTask(async (serviceScopeFactory, cancellationToken) =>
        //    {
        //        // Get services
        //        using var scope = serviceScopeFactory.CreateScope();
        //        var logger = scope.ServiceProvider.GetRequiredService<ILogger<File>>();

        //        try
        //        {
        //            // Do something expensive
        //             Console.WriteLine(23123);
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.LogError(ex, "Could not do something expensive");
        //        }
        //    });
        //    return Ok("ff");
        //}

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
