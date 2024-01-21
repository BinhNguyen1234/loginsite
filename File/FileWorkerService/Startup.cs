using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorkerService
{
    public class Startup
    {
        public void ConfigureServices( IServiceCollection services)
        {
            services.AddHostedService<Worker>();
            services.AddMVC
        }
    }
}
