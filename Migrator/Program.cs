using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.EntityFrameworkCore;

namespace VueFsharpCore2
{
    public class MigratorProgram
    {
        public static void Main(string[] args)
        {            
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<MigratorStartup>()
                .Build();
    }
}
