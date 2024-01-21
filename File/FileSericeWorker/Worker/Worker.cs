using FileSericeWorker.Test;
using System.Threading;

namespace FileWorkerService.Worker
{
    public class TaskProcessor : BackgroundService
    {
        private readonly TasksToRun _tasks;

        public TaskProcessor(TasksToRun tasks) => _tasks = tasks;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield(); // This will prevent background service from blocking start up of application

            while (stoppingToken.IsCancellationRequested == false)
            {
                try
                {
                    var taskToRun = _tasks.Dequeue(_tokenSource.Token);


                    await ExecuteTask(taskToRun);
                }
                catch (OperationCanceledException)
                {
                    // execution cancelled
                }
                catch (Exception e)
                {
                    // Catch and log all exceptions,
                    // So we can continue processing other tasks
                }
            }
        }
    }

    public class Worker1 : BackgroundService
    {
        private readonly ILogger<Worker1> _logger;

        public Worker1(ILogger<Worker1> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

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
}
