using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using PracticumPangea.processModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


namespace PracticumPangea.Controllers
{
    [Route("api/[controller]")]
    public class LoadDataController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "loaddata",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                DateTime now = DateTime.Now;
                string message = "LoadData - " + now.ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "loaddata",
                                     basicProperties: null,
                                     body: body);
                //Console.WriteLine(" [x] Sent {0}", message);
                return new string[] { "LoadData", now.ToString() };
            }

           // return new string[] { "LoadData", "FAILED" };
        }
       
    }
}
