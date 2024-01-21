using System.Collections.Concurrent;

namespace FileSericeWorker.Test
{
    public class TasksToRun
    {
        private readonly BlockingCollection<string> _tasks;

        public TasksToRun() => _tasks = new BlockingCollection<string>(new ConcurrentQueue<string>());

        public void Enqueue(string taskData) =>  _tasks.Add(taskData) ;

        public string Dequeue(CancellationToken token) => _tasks.Take(token);
    }
}
