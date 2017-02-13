using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using RabbitMQ.Client;
using System.Text;
using System.Net;
using System.Net.Http;
using PracticumPangea.processModels;
//using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
namespace PracticumPangea
{
    public class Program
    {
        private IHostingEnvironment _hostingEnvironment;
    
        public static void Main(string[] args)
        {
          

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();



        }


    }
}
