using FileSericeWorker.Service;
using FileWorkerService.Worker;
using Microsoft.AspNetCore.Mvc;

namespace FileSericeWorker.Controllers
{
    [Route("[controller]/[action]")]
    public class File : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<File> _logger;
        private readonly LogService _sv;

        public File(ILogger<File> logger, LogService sv)
        {
            _logger = logger;
            _sv = sv;
        }

        [HttpGet]
        public IActionResult runservice()
        {
            _sv.startLogging()
            return Ok("ff");
        }
        public IActionResult stopservice()
        {
            
            return Ok("ff");
        }
    }
}
