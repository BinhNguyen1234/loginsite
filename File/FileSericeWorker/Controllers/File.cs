using FileSericeWorker.Service;
using FileWorkerService.Worker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System.Net.NetworkInformation;

namespace FileSericeWorker.Controllers
{
    [Route("[controller]/[action]")]
    public class File : ControllerBase
    {

        private readonly ILogger<File> _logger;
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly IServiceProvider _serviceProvider;
        public File(ILogger<File> logger, IBackgroundTaskQueue backgroundTaskQueue, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _backgroundTaskQueue = backgroundTaskQueue ?? throw new ArgumentNullException(nameof(backgroundTaskQueue));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult runservice()
        {
            _backgroundTaskQueue.EnqueueTask(async (serviceScopeFactory, cancellationToken) =>
            {
                // Get services
                using var scope = serviceScopeFactory.CreateScope();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<File>>();

                try
                {
                    // Do something expensive
                     Console.WriteLine(23123);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Could not do something expensive");
                }
            });
            return Ok("ff");
        }

        [HttpGet]
        public IActionResult stopservice()
        {
            var schedulerFactory = _serviceProvider.GetRequiredService<ISchedulerFactory>();
            return Ok("ff");
        }
    }
}
