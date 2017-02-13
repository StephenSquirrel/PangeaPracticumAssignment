using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Net;
using System.Net.Http;
using ConsumeRabbit.processModels;
using Newtonsoft.Json;
namespace ConsumeRabbit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program myProgram = new Program();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "loaddata",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    using (var db = new PangeaPracticumContext())
                    {
                        string mygottenstring = "";
                        mygottenstring = myProgram.GetPangObject().GetAwaiter().GetResult().ToString();
                        List<PangObject.RootObject> ro = new List<PangObject.RootObject>();
                        List<PangeaRecords> recordsToAdd = new List<PangeaRecords>();
                        ro = JsonConvert.DeserializeObject<List<PangObject.RootObject>>(mygottenstring);
                        foreach (PangObject.RootObject rooty in ro)
                        {
                            PangeaRecords myrec = new PangeaRecords();
                            {
                                myrec.JsonData = JsonConvert.SerializeObject(rooty);
                                //db.PangeaRecords.Add(myrec);
                                recordsToAdd.Add(myrec);

                            }
                        }
                        if(recordsToAdd.Count > 0)
                        {
                            db.PangeaRecords.AddRange(recordsToAdd);
                            db.SaveChanges();
                        }
                       
                    }
                };
                channel.BasicConsume(queue: "loaddata",
                                     noAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
        public async Task<string> GetPangObject()
        {
            string requestUrl = "https://api.github.com/orgs/gopangea/repos";
         
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _accessToken);
                    //client.DefaultRequestHeaders.Add("UserAgent", "StephenSquirrel");
                    //client.DefaultRequestHeaders.Add("UserAgent", "StephenSquirrel");
                    //client.DefaultRequestHeaders.Add("UserAgent", "ConsumeRabbit");
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("StephenSquirrel");
                    //client.DefaultRequestHeaders
                    var data = await client.GetAsync(requestUrl);
                    var jsonResponse = await data.Content.ReadAsStringAsync();
                    if (jsonResponse != null)
                    {
                       
                        //sampleClass = JsonConvert.DeserializeObject<SampleClass>(jsonResponse);
                        //return sampleClass;
                        return jsonResponse.ToString();
                    }



                }
            }

            catch (WebException exception)
            {
                throw new WebException("An error has occurred while calling GetSampleClass method: " + exception.Message);
            }
            return "nope";
        }

    }
}
