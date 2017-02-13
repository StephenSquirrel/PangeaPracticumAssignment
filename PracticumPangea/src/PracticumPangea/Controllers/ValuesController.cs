using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using PracticumPangea.processModels;



namespace PracticumPangea.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<PangObject.RootObject> Get()
        {
            //return new string[] { "value1", "value2" };
            return retrievePangObjectFromFile();
        }
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{

        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(retrievePangObjectFromFilexx().ToString()), System.Text.Encoding.UTF8)
        //        //Content = new StringContent(JsonConvert.SerializeObject(, System.Text.Encoding.UTF8)
        //    };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //public static string SerializeToXml<T>(T value)
        //{
        //    //StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
        //    //XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    //serializer.Serialize(writer, value);
        //    //return writer.ToString();
        //}

        //public HttpResponseMessage getAllData()
        //{

        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(JsonConvert.SerializeObject(retrievePangObjectFromFilexx().ToString()), System.Text.Encoding.UTF8)
        //    };
        //}

        private string retrievePangObjectFromFilexx()
        {
            //         var pathToFile = env.ApplicationBasePath
            //+ Path.DirectorySeparatorChar.ToString()
            //+ "yourfolder"
            //+ Path.DirectorySeparatorChar.ToString()
            //+ "yourfilename.txt";

            string fileContent;
            List<PangObject.RootObject> ro = new List<PangObject.RootObject>();
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\Bilica-SPR\\documents\\visual studio 2015\\Projects\\PracticumPangea\\src\\PracticumPangea\\jsonData\\MyPangeaInfo.json"))
            {
                fileContent = reader.ReadToEnd();
                //ro = JsonConvert.DeserializeObject<List<PangObject.RootObject>>(fileContent);
            }
            //return ro[1].id.ToString();
            return fileContent;
        }
        private List<PangObject.RootObject> retrievePangObjectFromFile()
        {
            //         var pathToFile = env.ApplicationBasePath
            //+ Path.DirectorySeparatorChar.ToString()
            //+ "yourfolder"
            //+ Path.DirectorySeparatorChar.ToString()
            //+ "yourfilename.txt";

            string fileContent;
            List<PangObject.RootObject> ro = new List<PangObject.RootObject>();
            using (StreamReader reader = System.IO.File.OpenText("C:\\Users\\Bilica-SPR\\documents\\visual studio 2015\\Projects\\PracticumPangea\\src\\PracticumPangea\\jsonData\\MyPangeaInfo.json"))
            {
                fileContent = reader.ReadToEnd();
                ro = JsonConvert.DeserializeObject<List<PangObject.RootObject>>(fileContent);
            }
            return ro;
           
        }
    }
}
