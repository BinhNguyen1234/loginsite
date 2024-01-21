namespace FileSericeWorker.Service
{
    public class LogService
    {
        public async Task startLogging(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                    Console.WriteLine("Worker1 running at: {time}", DateTimeOffset.Now);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
